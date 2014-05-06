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
			Configuration c = new Configuration();
			const string file = "test.cfg";
			c.setValue<String>("1", "asdf");
			Configuration.save(file, c);
			c = null;
			c = Configuration.load(file);
		}
	}
}