using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerTracker.Server.Util;

namespace ServerTests {
	[TestClass]
	public class DatabaseTests {
		[TestMethod]
		public void TestConnection() {
			DatabaseManager dbman = new DatabaseManager("127.0.0.1", 3306, "root", "root", "playertracker");
			dbman.connect();
		}
	}
}
