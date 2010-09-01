using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Context;
using System.IO;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for OutputTest
    /// </summary>
    [TestClass]
    public class OutputTest
    {
        private static Output output;
        private static DirectoryInfo dir;

        public OutputTest(){}

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
            dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated"));
            output = new Output(dir.FullName, "EDMTest");
        }

        [TestMethod]
        public void outputNotNull()
        {
            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void canGetRttiProjectPath()
        {
            String res = output.RttiProjectPath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Rtti"), res);
        }
        [TestMethod]
        public void canGetRttiBasePath()
        {
            String res = output.RttiBasePath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Rtti\Base"), res);
        }
        [TestMethod]
        public void canGetEntityProjectPath()
        {
            String res = output.EntityProjectPath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Entity"), res);
        }
        [TestMethod]
        public void canGetEntityDataPath()
        {
            String res = output.EntityDataPath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Entity\Data"), res);
        }
        [TestMethod]
        public void canGetEntityDataBasePath()
        {
            String res = output.EntityDataBasePath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Entity\Data\Base"), res);
        }
        [TestMethod]
        public void canGetEntityDomainPath()
        {
            String res = output.EntityDomainPath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Entity\Domain"), res);
        }
        [TestMethod]
        public void canGetEntityDataInterfacesPath()
        {
            String res = output.EntityDataInterfacesPath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Entity\DataInterfaces"), res);
        }
        [TestMethod]
        public void canGetEntityDataInterfacesBasePath()
        {
            String res = output.EntityDataInterfacesBasePath;
            Assert.AreEqual(Path.Combine(dir.FullName, @"EDMTest.Entity\DataInterfaces\Base"), res);
        }
        [TestMethod]
        public void canGetFeProjectPath()
        {
            String res = output.FeProjectPath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Fe"), res);
        }
        [TestMethod]
        public void canGetServicesProjectPath()
        {
            String res = output.ServicesProjectPath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Services"), res);
        }
        [TestMethod]
        public void canGetWsProjectPath()
        {
            String res = output.WsProjectPath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Ws"), res);
        }
        [TestMethod]
        public void canGetPersistencePath()
        {
            String res = output.PersistencePath;
            Assert.AreEqual(Path.Combine(dir.FullName, "EDMTest.Persistence"), res);
        }
    }
}
