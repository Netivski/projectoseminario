using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Context;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for EDMXPathTest
    /// </summary>
    [TestClass]
    public class EDMXPathTest
    {
        private static EDMXPath xpath;
        public EDMXPathTest(){}

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
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

        [ClassInitialize]
        public static void init(TestContext ctx)
        {
            xpath = new EDMXPath();
        }

        [TestMethod]
        public void EDMXPathNotNull()
        {
            Assert.IsNotNull(xpath);
        }
        [TestMethod]
        public void canGetRoot()
        {
            Assert.AreEqual(xpath.Root, "/");
        }
        [TestMethod]
        public void  canGetUserTypes()
        {
            Assert.AreEqual(xpath.UserTypes, "/solution/userTypes");
        }
        [TestMethod]
        public void canGetEntities()
        {
            Assert.AreEqual(xpath.Entities, "/solution/entities");
        }
        [TestMethod]
        public void canGetEntity()
        {
            Assert.AreEqual(xpath.Entity, "/solution/entities/entity");
        }
        [TestMethod]
        public void canGetEntityFields()
        {
            Assert.AreEqual(xpath.EntityFields, "./fields");
        }
    }
}
