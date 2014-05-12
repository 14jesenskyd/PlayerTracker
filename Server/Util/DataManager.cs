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

		private String generateUUID() {
			//TODO generate
			return "";
		}

		private bool attemptLogin(String user, String pass) {
			//TODO verify credentials
			Server.getSingleton().getDbManager();
			return false;
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
			while (this.running){
				foreach (Connection c in Server.getSingleton().getConnectionManager().getConnections().Values) {
					if (c.isClosed()) {
						Server.getSingleton().getConnectionManager().getConnections().Remove(c.getAddress());
					} else
						try {
							if (c.dataRemaining()) {
								Packet p = c.readData();
								Packet response = null;

								if (p.getType().Equals(PacketType.LOGIN)) {
									response = new LoginResponsePacket(LoginResponsePacket.LoginResponse.SUCCESS);
								} else if (p.getType().Equals(PacketType.FETCH_DATA)) {
									FetchPacket packet = new FetchPacket(p);
									MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select * from `players` where `serverId`=(select `serverId` from `servers` where `serverName`=\""+packet.getServer()+"\") and `playerName` like \""+packet.getName()+"\";");
									if(reader.Read()){
										response = new DataResponsePacket(reader.GetString("playerName"), packet.getServer(), reader.GetString("notes"), reader.GetString("violations"), UserViolationLevel.getViolationLevelFromByte(reader.GetByte("violationLevel")), reader.GetInt32("id").ToString());
									}else{

                                        MySqlDataReader r = Server.getSingleton().getDbManager().executeReader("select `serverId` from `servers` where `serverName`=\"" + packet.getServer() + "\"");
                                        r.Read();
                                        Server.getSingleton().getDbManager().executeNonQuery("insert into `players` (`serverId`, `playerName`, `notes`, `violations`, `violationLevel`) values(" + r.GetInt32("serverId") + ", \"" + packet.getName() + "\", \"\", \"\", " + UserViolationLevel.GOOD.getByteIdentity() + ")");
                                        MySqlDataReader z = Server.getSingleton().getDbManager().executeReader("select `id` from `players` where `serverId`="+r.GetInt32("serverId")+" and `playerName`=\""+packet.getName()+"\"");
                                        z.Read();
										response = new DataResponsePacket(packet.getName(), packet.getServer(), "", "", UserViolationLevel.GOOD, z.GetInt32("id").ToString());
										r.Close();
									}
									reader.Close();
								}else if(p.getType().Equals(PacketType.LIST_REQUEST)){
									List<string> servers = new List<string>();
									MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select * from `servers`");
									while (reader.Read())
										servers.Add(reader.GetString("serverName"));
									response = new ServerListResponsePacket(servers);
									reader.Close();
								}else if(p.getType().Equals(PacketType.REGISTRATION)){
									RegistrationPacket packet = new RegistrationPacket(p);
									MySqlDataReader reader = Server.getSingleton().getDbManager().executeReader("select `serverAccess` from `registrationKeys` where `key`=\""+packet.getRegistrationKey()+"\"");
									if(reader.Read()){
										Server.getSingleton().getDbManager().executeScalar("insert into `users` (`firstName`, `lastName`, `user`, `pass`, `serverAccess`) values(\""+packet.getFirstName()+"\", \""+packet.getLastName()+"\", \""+packet.getUsername()+"\", \""+packet.getPasswordHash()+"\", \""+reader.GetString("serverAccess")+"\");");
									}
								}else if(p.getType().Equals(PacketType.DATA_UPDATE)){
									DataUpdatePacket packet = new DataUpdatePacket(p);
									Server.getSingleton().getDbManager().executeNonQuery("update `players` set `playerName`=\""+packet.getPlayer()+"\", `notes`=\""+packet.getNotes()+"\", `violations`=\""+packet.getViolations()+"\", `violationLevel`="+packet.getViolationLevel().getByteIdentity()+" where `id`="+packet.getID()+";");
								}
								if(response != null)
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