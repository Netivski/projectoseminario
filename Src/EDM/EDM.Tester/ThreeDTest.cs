using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Context;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for ThreeDTest
    /// </summary>
    [TestClass]
    public class ThreeDTest
    {
        private static string filePath;
        private static ThreeD threedFile;

        public ThreeDTest(){}

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
        public static void Init(TestContext ctx)
        {
            filePath   = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\3D.xml");
            threedFile = new ThreeD(filePath);
        }
        
        [TestMethod]
        public void ThreeDFileNotNull()
        {
            Assert.IsNotNull(threedFile);
        }
        [TestMethod]
        public void CanGetFullName()
        {
            Assert.AreEqual(new FileInfo(filePath).FullName, threedFile.FullName);
        }
        [TestMethod]
        public void CanGetName()
        {
            Assert.AreEqual(new FileInfo(filePath).Name, threedFile.Name);
        }
        [TestMethod]
        public void CanGetDirectoryFullName()
        {
            Assert.AreEqual(new FileInfo(filePath).Directory.FullName, threedFile.DirectoryFullName);
        }
        [TestMethod]
        public void CanGetCompanyName()
        {
            Assert.AreEqual("ISEL", threedFile.CompanyName);
        }
        [TestMethod]
        public void CanGetProjectName()
        {
            Assert.AreEqual("Sample", threedFile.ProjectName);
        }
        [TestMethod]
        public void CanGetNameSpace()
        {
            Assert.AreEqual("ISEL.Sample", threedFile.NameSpace);
        }
        [TestMethod]
        public void CanGetBaseName()
        {
            Assert.AreEqual("ISEL.Sample", threedFile.BaseName);
        }
        [TestMethod]
        public void CanGetContent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            Assert.AreEqual(doc.Name, threedFile.Content.Name);
            Assert.AreEqual(doc.LastChild.Name, threedFile.Content.LastChild.Name);
            Assert.AreEqual(doc.FirstChild.Name, threedFile.Content.FirstChild.Name);
        }
    }
}
