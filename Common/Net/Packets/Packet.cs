using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace PlayerTracker.Common.Net.Packets {
	public class Packet {
		private PacketType type;
		private byte[] data;

		public Packet(PacketType type, params byte[] data) {
			this.type = type;
			this.data = data;
		}

		public Packet(Packet copy) {
			this.data = copy.data;
			this.type = copy.type;
		}

		public PacketType getType() {
			return this.type;
		}

		public void sendData(Socket sock) {
			sock.Send(this.getAmmendedData(), SocketFlags.None);
		}

		public void sendData(Connection conn) {
			conn.send(this.getAmmendedData());
		}

		public byte[] getAmmendedData() {
			byte[] sigma = new byte[this.data.Length + this.type.getHeader().Length];
			Array.ConstrainedCopy(this.type.getHeader(), 0, sigma, 0, this.type.getHeader().Length);
			Array.ConstrainedCopy(this.data, 0, sigma, this.type.getHeader().Length, this.data.Length);
			return sigma;
		}

		public override string ToString() {
			String s = "Packet[";
			foreach (byte b in this.getAmmendedData())
				s += b + ", ";
			return s.Substring(0, s.Length - 2) + "]";
		}

		/**
		 * Gets a section of the data cached within
		 * this {@code Packet}, based on the specified
		 * {@code section}. A {@code section} is defined
		 * explicitly as the data between two separator
		 * bytes ({@code 0x0}), or the beginning and/or the
		 * end of the data stored if there is no such endpoint.<br />
		 * <br />
		 * Sections begin counting at 0, just as arrays do.
		 *
		 * @param section The section of data to get, bound by
		 *                {@code 0x0}, the beginning, end, or any
		 *                combination thereof, depending on what data
		 *                is stored.
		 * @return The bytes between the endpoints of the specified
		 * {@code section}.
		 */
		public byte[] getDataSection(int section) {
			List<Byte> r = new List<Byte>();
			int iteration = 0, index = 0;
			bool t = true;

			while (t) {
				if (this.data[index] == 0)
					iteration++;
				if (iteration == section) {
					if (section != 0)
						index++;
					while (t && index < this.data.Length) {
						if (this.data[index] == (byte)0x0) {
							t = false;
						} else {
							r.Add(this.data[index++]);
						}
						if (this.data.Length == index)
							t = false;
					}
				}
				index++;
			}
			return NetUtils.byteListToArray(r);
		}

		/**
		 * Checks whether or not the {@code n}th {@code section}
		 * exists.<br />
		 * <br />
		 * A {@code section} is defined as a block of data bounded
		 * by a {@code byte} of {@code 0}.
		 *
		 * @param section The section of data to check if it exists.
		 * @return Whether or not the specified section exists.
		 */
		public bool hasDataSection(int section) {
			try {
				this.getDataSection(section);
			} catch (Exception) {
				//ignore exception
				return false;
			}
			return true;
		}
	}
}
