using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using PlayerTracker.Common.Exceptions;

namespace PlayerTracker.Common.Util {
	[Serializable]
	public sealed class Configuration {
		private const long serialVersionUID = 16632074508205L;
		private Dictionary<String, Object> values;

		/**
		 * Instantiates a new {@code Configuration} instance. Does nothing
		 * besides initialize the values.<br />
		 * <br />
		 * For loading a configuration, one should instead use {@link #load(String)}
		 *
		 * @see #load(String)
		 */
		public Configuration() {
			this.values = new Dictionary<String, Object>();
		}

		/**
		 * Serializes the given {@code Configuration} instance, then writes
		 * it to file, given the file name. Serialization is based on the
		 * UID {@code 16632074508205}.
		 *
		 * @param filename The file to save to.
		 * @param clazz    The {@code Configuration} instance to save using.
		 * @throws IOException When a {@code FileOutputStream} or
		 *                     {@code ObjectOutputStream} either cannot be instantiated or fail to write.
		 */
		public static void save(String filename, Configuration clazz) {
			BinaryFormatter f = new BinaryFormatter();
			Stream fos = File.Create(filename);
			f.Serialize(fos, clazz);
			fos.Close();
		}

		/**
		 * Deserialization is based on the UID {@code 16632074508205}.
		 *
		 * @param filename The file to load a {@code Configuration}
		 *                 instance from.
		 * @return The instance of {@code Configuration} which was
		 * loaded.
		 * @throws IOException If the file cannot be found, or is
		 *                     already being used.
		 */
		public static Configuration load(String filename) {
			if (File.Exists(filename)) {
				BinaryFormatter f = new BinaryFormatter();
				Stream fis = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
				Configuration c = (Configuration)f.Deserialize(fis);
				fis.Close();
				return c;
			} else {
				return new Configuration();
			}
		}

		/**
		 * Gets the value of the key given within this {@code Configuration}
		 * instance's value listing. If the key does not exist, the given
		 * {@code defaultVal} will be returned instead.
		 *
		 * @param key        The key to retrieve the value of
		 * @param defaultVal The value to return if the given {@code key}
		 *                   does not exist
		 * @param <E>        The expected type of the returned value
		 * @return The value stored at {@code key}, if it exists; otherwise,
		 * {@code defaultVal} will be returned.
		 */
		public E getValue<E>(String key, E defaultVal) {
			return this.containsKey(key) ? (E)this.values[key] : defaultVal;
		}

		/**
		 * Retrieves the value at the specified {@code key}. If the
		 * {@code key} represents no value, a {@code NoSuchKeyException}
		 * will be thrown instead.
		 *
		 * @param key The key to retrieve the value of
		 * @param <E> The expected type of the value at {@code key}
		 * @return The value at {@code key}, if it exists
		 * @throws NoSuchKeyException If the given {@code key} does not exist.
		 */
		public E getValue<E>(String key) {
			if (!this.containsKey(key))
				throw new NoSuchKeyException();
			return (E)this.values[key];
		}

		/**
		 * Assigns the value of the given {@code key} to {@code value}. As the
		 * parity of values should be one-to-one, this will cause any existing
		 * value at the location of {@code key} to be overwritten.
		 *
		 * @param key   The key to put the {@code value} at.
		 * @param value The value to put at the {@code key}'s location.
		 * @param <E>   The type of the {@code value}.
		 */
		public void setValue<E>(String key, E value) {
			if (this.containsKey(key))
				this.values[key] = value;
			else
				this.values.Add(key, value);
		}

		/**
		 * Checks whether or not the given {@code key} exists in this
		 * {@code Configuration}'s value listing.
		 *
		 * @param key The key to look for.
		 * @return {@code true} if the key is present and represents a value;
		 * {@code false} otherwise.
		 */
		public bool containsKey(String key) {
			return this.values.ContainsKey(key);
		}

		/**
		 * {@inheritDoc}
		 */
		public override string ToString() {
			return "Configuration[size=" + this.values.Count + "]";
		}
	}
}
