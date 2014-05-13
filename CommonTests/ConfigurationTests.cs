using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerTracker.Common.Util;

namespace CommonTests {
	[TestClass]
	public class ConfigurationTests {
		[TestMethod]
		public void TestSaveLoad() {
			const string file = "test.cfg";
			Configuration c = new Configuration();
			c.setValue<String>("1", "asdf");
			Configuration.save(file, c);
			c = null;
			c = Configuration.load(file);
		}
	}
}