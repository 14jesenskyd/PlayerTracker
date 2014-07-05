using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerTracker.Server.Util;
using PlayerTracker.Common.Util;

namespace ServerTests {
	[TestClass]
	public class DatabaseTests {
		[TestMethod]
		public void TestConnection() {
			DatabaseManager dbman = new DatabaseManager("127.0.0.1", 3306, "root", "root", "playertracker-test");
			dbman.connect();
			dbman.Dispose();
		}

		[TestMethod]
		public void TestTables() {
			DatabaseManager dbman = new DatabaseManager("127.0.0.1", 3306, "root", "root", "playertracker-test", KVFactory.str("UserTable", "users"), KVFactory.str("ServerTable", "servers"), KVFactory.str("PlayerTable", "players"), KVFactory.str("AttachmentTable", "attachments"));
			dbman.connect();

			Assert.AreEqual<string>("users", dbman.getTable("UserTable"));
			Assert.AreEqual<string>("servers", dbman.getTable("ServerTable"));
			Assert.AreEqual<string>("attachments", dbman.getTable("AttachmentTable"));
			Assert.AreEqual<string>("players", dbman.getTable("PlayerTable"));

			dbman.Dispose();
		}
	}
}
