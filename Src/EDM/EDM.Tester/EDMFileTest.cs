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
    /// Summary description for EDMFileTest
    /// </summary>
    [TestClass]
    public class EDMFileTest
    {
        private static string filePath;
        private static EDMFile edmFile;

        public EDMFileTest(){}

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
            filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\3D.xml");
            edmFile = new EDMFile(filePath);
        }
        
        [TestMethod]
        public void EDMFileNotNull()
        {
            Assert.IsNotNull(edmFile);
        }
        [TestMethod]
        public void canGetFullName()
        {
            Assert.AreEqual(new FileInfo(filePath).FullName, edmFile.FullName);
        }
        [TestMethod]
        public void canGetName()
        {
            Assert.AreEqual(new FileInfo(filePath).Name, edmFile.Name);
        }
        [TestMethod]
        public void canGetDirectoryFullName()
        {
            Assert.AreEqual(new FileInfo(filePath).Directory.FullName, edmFile.DirectoryFullName);
        }
        [TestMethod]
        public void canGetCompanyName()
        {
            Assert.AreEqual("ISEL", edmFile.CompanyName);
        }
        [TestMethod]
        public void canGetProjectName()
        {
            Assert.AreEqual("Sample", edmFile.ProjectName);
        }
        [TestMethod]
        public void canGetNameSpace()
        {
            Assert.AreEqual("ISEL.Sample", edmFile.NameSpace);
        }
        [TestMethod]
        public void canGetBaseName()
        {
            Assert.AreEqual("ISEL.Sample", edmFile.BaseName);
        }
        [TestMethod]
        public void canGetContent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            Assert.AreEqual(doc.Name, edmFile.Content.Name);
            Assert.AreEqual(doc.LastChild.Name, edmFile.Content.LastChild.Name);
            Assert.AreEqual(doc.FirstChild.Name, edmFile.Content.FirstChild.Name);
        }
    }
}
