using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net.Packets;

namespace CommonTests {
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class PacketTests {
		public PacketTests() {
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestDT() {
			DateTime a = DateTime.Now;
			DateTime b = DateTime.Parse(a.ToShortDateString() + " " + a.ToLongTimeString());
			Assert.AreEqual<string>(a.ToShortDateString() + " " + a.ToLongTimeString(), b.ToShortDateString() + " " + b.ToLongTimeString());
		}

		[TestMethod]
		public void TestALRPacket() {
			List<Attachment> l = new List<Attachment>();
			DateTime t = DateTime.Now;
			DateTime t2;
			AttachmentListResponsePacket packet;
			List<Attachment> z;
			System.Threading.Thread.Sleep(10000);
			t2 = DateTime.Now;

			l.Add(new Attachment(t, "1"));
			l.Add(new Attachment(t2, "2"));
			packet = new AttachmentListResponsePacket(l);

			z = packet.getAttachments();
			Assert.AreEqual(l.Count, z.Count);
			for (int i = 0; i < l.Count; i++) {
				Assert.IsTrue(z[i].Equals(l[i]));
			}
		}
	}
}
