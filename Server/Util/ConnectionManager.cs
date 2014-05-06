using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Exceptions;
using PlayerTracker.Common.Net;
using PlayerTracker.Server.Listeners;
using PlayerTracker.Server.Events;

namespace PlayerTracker.Server.Util {
	public class ConnectionManager {
		private Dictionary<IPAddress, Connection> connections;
		private Socket socket;
		private bool accepting;
		private List<ConnectionListener> listeners;

		/// Instantiates a new {@code ConnectionManager}.<br />
		/// <br />
		/// {@code ConnectionManager} is a subclass of {@link java.lang.Thread},
		/// and should be treated with care upon accessing any members.<br />
		/// <br />
		/// Given the purpose of the class, queries should be wary of
		/// thread-safety with whatever actions they may perform.
		public ConnectionManager(int port, String host = null) {
			this.connections = new Dictionary<IPAddress, Connection>();
			if (host != null) {
				this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPAddress ip = IPAddress.Parse(host);
				EndPoint ep = new IPEndPoint(ip, port);
				this.socket.Bind(ep);
			} else
				this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this.listeners = new List<ConnectionListener>();
			this.accepting = true;
		}

		/**
		 * Gets all of the currently live connections to the {@code Server}
		 * singleton.<br />
		 * <br />
		 * Currently, the result is stored in a {@code HashMap}, ordered by
		 * {@code InetAddress}es, which could lead to issues if more than one
		 * person connects via the same ethernet uplink.<br />
		 * <br />
		 * As such, this implementation is volatile and subject to change at
		 * any time, and is likely to do so in the future (likely to
		 * {@code List}).
		 *
		 * @return A {@code HashMap} of all {@code Connection}s to the
		 * {@code Server} singleton. Subject to change and should not
		 * be relied upon.
		 */
		public Dictionary<IPAddress, Connection> getConnections() {
			return this.connections;
		}

		public Connection getConnection(IPAddress addr) {
			return this.connections[addr];
		}

		/**
		 * Registers an observer to be invoked upon the server's
		 * {@code ConnectionManager} receiving a new connection.
		 * This will not fire if for some internal reason
		 * the connection refuses abruptly.<br />
		 * <br />
		 * Returns an id -- that of the listener which is being registered.
		 * This id can be used to remove the listener from operation, if
		 * so desired.
		 *
		 * @param listener The {@code ConnectionListener} implementation to
		 *                 invoke upon event firing.
		 * @return The ID of the listener.
		 * @see #unregisterConnectionListener(int)
		 */
		public int registerConnectionListener(ConnectionListener listener) {
			if (!this.listeners.Contains(listener)) {
				this.listeners.Add(listener);
			}
			return this.listeners.IndexOf(listener);
		}

		/**
		 * Unregisters an observer from the queue of invocation when the
		 * server receives a connection. Removing a listener will not affect
		 * the ids of other listeners in any way. Using an index of {@code -1}
		 * or that which exceeds the upper boundary of the listener listing
		 * will cause nothing to happen.
		 *
		 * @param id The id to remove.
		 */
		public void unregisterConnectionListener(int id) {
			if (id < 0 || id >= this.listeners.Count)
				return;
			this.listeners[id] = null;
		}

		/**
		 * {@inheritDoc}
		 */
		public void run() {
			while (this.accepting) {
				try {
					Socket sock = this.socket.Accept();
					Connection conn = new Connection(sock);
					this.connections[((IPEndPoint)sock.RemoteEndPoint).Address] = conn;
					this.updateConnectionListeners(new ConnectionEvent(conn));
				} catch (IOException e) {
					Server.getLogger().error(e.Message);
				} catch (InvalidArgumentException e) {
					Server.getLogger().error(e.Message);
				}
			}
		}

		/**
		 * Calls {@link me.jesensky.dan.playertracker.listeners.ConnectionListener#onConnectEvent(me.jesensky.dan.playertracker.events.ConnectionEvent)}
		 * for all {@code ConnectionListener}s registered to
		 * this {@code ConnectionManager}. This method requires a
		 * {@code ConnectionEvent} instance to pass to each
		 * listener thereof.
		 *
		 * @param evt The {@code ConnectionEvent} to pass to each
		 *            {@code ConnectionListener}.
		 */
		private void updateConnectionListeners(ConnectionEvent evt) {
			foreach (ConnectionListener listener in this.listeners) {
				if (listener != null)
					listener.onConnectEvent(evt);
			}
		}

		public void closeConnections() {
			foreach (Connection connection in this.getConnections().Values)
				if (connection != null && !connection.isClosed())
					try {
						connection.close();
						this.getConnections().Remove(connection.getAddress());
					} catch (IOException e) {
						//ignore, likely already closed
					}
		}

		public override string ToString() {
			return "ConnectionManager[connections=" + this.connections.Count + "]";
		}
	}
}
