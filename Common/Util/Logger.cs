using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PlayerTracker.Common.Util {
	public class Logger {
		enum Level {
			INFO,
			WARNING,
			SEVERE
		}

		private StreamWriter log;
		private String filename;

		public Logger(String filename) {
			this.filename = filename;
			this.log = new StreamWriter(filename);
		}

		public void info(String s) {
			this.write(Level.INFO, s);
		}

		public void warning(String s) {
			this.write(Level.WARNING, s);
		}

		public void error(String s) {
			this.write(Level.SEVERE, s);
		}

		private void write(Level logLevel, String text) {
			try {
				this.log.WriteLine("[" + TimeUtils.getTime() + "] [" + logLevel.ToString() + "] " + text);
				this.log.Flush();
			} catch (IOException e) {
				//print to console -- there's not really much you can do about it
				Console.WriteLine(e.Message);
			}
		}

		public override string ToString() {
			return "Logger[" + this.filename + "]";
		}
	}
}