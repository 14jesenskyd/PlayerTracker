using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Exceptions;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;
using PlayerTracker.Server.Events;
using PlayerTracker.Server.Listeners;
using System.Threading;
using MySql.Data.MySqlClient;

namespace PlayerTracker.Server.Util {
	public class DataManager {
		private const int SLEEP_DURATION = 35;
		private List<DataTransmissionListener> listeners;
		private bool running;
		private Thread thread;

		public DataManager() {
			this.listeners = new List<DataTransmissionListener>();
			this.running = false;
		}

		public int registerDataTransmissionListener(DataTransmissionListener listener) {
			if (!this.listeners.Contains(listener))
				this.listeners.Add(listener);
			return this.listeners.IndexOf(listener);
		}

		private string generateUUID() {
			//TODO generate
			return "";
		}

		public void stop() {
			this.running = false;
			this.thread.Abort();
		}

		public void start() {
			this.running = true;
			new Thread(new ThreadStart(run)).Start();
		}

		private void run() {
			this.thread = Thread.CurrentThread;
			while (this.running) {
				foreach (Connection c in Server.getSingleton().getConnectionManager().getConnections().Values) {
					if (c.isClosed()) {
						Server.getSingleton().getConnectionManager().getConnections().Remove(c.getAddress());
					} else
						try {
							if (c.dataRemaining()) {
								Packet p = c.readData();
								Packet response = null;

								if (p.getType().Equals(PacketType.LOGIN)) {
									LoginPacket packet = new LoginPacket(p);
									//MySqlDataReader r = Server.getSingleton().getDbManager().executeReader("select `id` from `users` where `user`=\"" + packet.getUser() + "\" and `pass`=\"" + packet.getPasswordHash() + "\"");
									MySqlDataReader r = Server.getSingleton().getDbManager().prepareCommand("select `id` from `users` where `user`=?User and `pass`=?Password;", KVFactory.obj("?User", packet.getUser()), KVFactory.obj("?Password", packet.getPasswordHash())).ExecuteReader();
									if (r.Read()) {
										response = new LoginResponsePacket(LoginResponsePacket.LoginResponse.SUCCESS, r.GetInt32("id").ToString());
									} else {
										response = new LoginResponsePacket(LoginResponsePacket.LoginResponse.FAILURE);
									}
									r.Close();
								} else if (p.getType().Equals(PacketType.FETCH_DATA)) {
									FetchPacket packet = new FetchPacket(p);
									//MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select * from `players` where `serverId`=(select `serverId` from `servers` where `serverName`=\"" + packet.getServer() + "\") and `playerName` like \"" + packet.getName() + "\";");
									MySqlDataReader reader = Server.getSingleton().getDbManager().prepareCommand("select * from `players` where `serverId`=(select `serverId` from `servers` where `serverName`=?Server) and `playerName` like ?Name;", KVFactory.obj("?Server", packet.getServer()), KVFactory.obj("?Name", packet.getName())).ExecuteReader();
									if (reader.Read()) {
										response = new DataResponsePacket(reader.GetString("playerName"), packet.getServer(), reader.GetString("notes"), reader.GetString("violations"), UserViolationLevel.getViolationLevelFromByte(reader.GetByte("violationLevel")), reader.GetInt32("id").ToString(), reader.GetInt32("serverId").ToString());
									} else {
										reader.Close();
										//MySqlDataReader r = Server.getSingleton().getDbManager().executeReader("select `serverId` from `servers` where `serverName`=\"" + packet.getServer() + "\"");
										MySqlDataReader r = Server.getSingleton().getDbManager().prepareCommand("select `serverId` from `servers` where `serverName`=", KVFactory.obj("?Server", packet.getServer())).ExecuteReader();
										r.Read();
										int serverId = r.GetInt32("serverId");
										r.Close();
										//Server.getSingleton().getDbManager().executeNonQuery("insert into `players` (`serverId`, `playerName`, `notes`, `violations`, `violationLevel`) values(" + serverId + ", \"" + packet.getName() + "\", \"\", \"\", " + UserViolationLevel.GOOD.getByteIdentity() + ")");
										Server.getSingleton().getDbManager().prepareCommand("insert into `players` (`serverId`, `playerName`, `notes`, `violations`, `violationLevel`) values(?ServerId, ?Name, ?Notes, ?Violations, ?ViolationLevel);", KVFactory.obj("?ServerId", serverId), KVFactory.obj("?Name", packet.getName()), KVFactory.obj("?Notes", ""), KVFactory.obj("?Violations", ""), KVFactory.obj("?ViolationLevel", UserViolationLevel.GOOD.getByteIdentity())).ExecuteNonQuery();
										//MySqlDataReader z = Server.getSingleton().getDbManager().executeReader("select `id`,`serverId` from `players` where `serverId`=" + serverId + " and `playerName`=\"" + packet.getName() + "\"");
										MySqlDataReader z = Server.getSingleton().getDbManager().prepareCommand("select `id`,`serverId` from `players` where `serverId`=" + serverId + " and `playerName`=\"" + packet.getName() + "\"").ExecuteReader();
										z.Read();
										response = new DataResponsePacket(packet.getName(), packet.getServer(), "", "", UserViolationLevel.GOOD, z.GetInt32("id").ToString(), z.GetInt32("serverId").ToString());
										z.Close();
									}
									reader.Close();
								} else if (p.getType().Equals(PacketType.LIST_REQUEST)) {
									List<string> servers = new List<string>();
									MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select * from `servers`");
									while (reader.Read())
										servers.Add(reader.GetString("serverName"));
									response = new ServerListResponsePacket(servers);
									reader.Close();
								} else if (p.getType().Equals(PacketType.REGISTRATION)) {
									RegistrationPacket packet = new RegistrationPacket(p);
									//MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select `serverAccess` from `registrationKeys` where `key`=\"" + packet.getRegistrationKey() + "\"");
									MySqlDataReader reader = Server.getSingleton().getDbManager().prepareCommand("select `serverAccess` from `registrationKeys` where `key`=?Key", KVFactory.obj("?Key", packet.getRegistrationKey())).ExecuteReader();
									if (reader.Read()) {
										//Server.getSingleton().getDbManager().executeScalar("insert into `users` (`firstName`, `lastName`, `user`, `pass`, `serverAccess`) values(\"" + packet.getFirstName() + "\", \"" + packet.getLastName() + "\", \"" + packet.getUsername() + "\", \"" + packet.getPasswordHash() + "\", \"" + reader.GetString("serverAccess") + "\");");
										Server.getSingleton().getDbManager().prepareCommand("insert into `users` (`firstName`, `lastName`, `user`, `pass`, `serverAccess`) values(?FirstName, ?LastName, ?Username, ?Password, ?AccessString);", new KeyValuePair<string, object>("?", packet.getFirstName()), new KeyValuePair<string, object>("?", packet.getLastName()), new KeyValuePair<string, object>("?", packet.getPasswordHash()), new KeyValuePair<string, object>("?", reader.GetString("serverAccess"))).ExecuteScalar();
									}
								} else if (p.getType().Equals(PacketType.DATA_UPDATE)) {
									DataUpdatePacket packet = new DataUpdatePacket(p);
									//Server.getSingleton().getDbManager().executeNonQuery("update `players` set `playerName`=\"" + packet.getPlayer() + "\", `notes`=\"" + packet.getNotes() + "\", `violations`=\"" + packet.getViolations() + "\", `violationLevel`=" + packet.getViolationLevel().getByteIdentity() + " where `id`=" + packet.getID() + ";");
									Server.getSingleton().getDbManager().prepareCommand("update `players` set `playerName`=?Player, `notes`=?Notes, `violations`=?Violations, `violationLevel`=?ViolationLevel where `id`=?Id;", KVFactory.obj("?Player", packet.getPlayer()), KVFactory.obj("?Notes", packet.getNotes()), KVFactory.obj("?Violations", packet.getViolations()), KVFactory.obj("?ViolationLevel", packet.getViolationLevel().getByteIdentity()), KVFactory.obj("?Id", packet.getID())).ExecuteNonQuery();
								} else if (p.getType().Equals(PacketType.ATTACHMENT_LIST_REQ)) {
									AttachmentListRequestPacket packet = new AttachmentListRequestPacket(p);
									List<Attachment> attachments = new List<Attachment>();
									MySqlDataReader r = Server.getSingleton().getDbManager().prepareCommand("select `screenshotId`,`uploadDate`,`uploadingUserId` from `screenshots` where `playerId`=?PlayerId and `serverId`=?ServerId",
									KVFactory.obj("?PlayerId", packet.getPlayerId()),
									KVFactory.obj("?ServerId", packet.getServerId())).ExecuteReader();
									
									while (r.Read()) {
										attachments.Add(new Attachment(r.GetDateTime("uploadDate"), r.GetInt32("screenshotId").ToString(), r.GetInt32("uploadingUserId").ToString()));
									}
									response = new AttachmentListResponsePacket(attachments);
									r.Close();
								} else if (p.getType().Equals(PacketType.UPLOAD_ATTACHMENT)) {
									UploadAttachmentPacket packet = new UploadAttachmentPacket(p);
									MySqlCommand cmd = Server.getSingleton().getDbManager().prepareCommand("insert into `screenshots` (`playerId`, `serverId`, `data`, `uploadDate`, `uploadingUserId`, `dataLength`) values(?playerId, ?serverId, ?attachmentData, ?dateTime, ?userId)",
										KVFactory.obj("?PlayerId", packet.getPlayerId()),
										KVFactory.obj("?ServerId", packet.getServerId()),
										KVFactory.obj("?AttachmentData", packet.getAttachmentData()),
										KVFactory.obj("?dateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
										KVFactory.obj("?userId", packet.getUserId()));
									
									cmd.ExecuteNonQuery();
								} else if (p.getType().Equals(PacketType.ATTACHMENT_REQUEST)) {
									AttachmentRequestPacket packet = new AttachmentRequestPacket(p);
									MySqlDataReader r = Server.getSingleton().getDbManager().executeReader("select `data`,`dataLength` from `screenshots` where `screenshotId`=" + packet.getId());
									r.Read();
									byte[] buffer = (byte[])r.GetValue(0);
									response = new AttachmentResponsePacket(buffer);
									r.Close();
								}
								if (response != null)
									response.sendData(c);
							}
						} catch (InvalidPacketException e) {
							Server.getLogger().error(e.Message);
						}
				}
				Thread.Sleep(SLEEP_DURATION);
			}
		}
	}
}