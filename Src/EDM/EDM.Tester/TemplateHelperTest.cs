using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Utils;
using EDM.Generator.Utils.XML;

namespace EDM.Tester
{
    /// <summary>
    /// Test class for EDM.Generator.Utils.TemplateHelper
    /// </summary>
    [TestClass]
    public class TemplateHelperTest
    {
        private static string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles");

        public TemplateHelperTest(){}

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

        [TestMethod]
        public void canRenderNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(Path.Combine(path, @"3D.xml")));
            XmlNode node = Get.GetNode(doc, "/solution/entities/*[@name = 'LP']");
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(Path.Combine(path, @"XSLT\Entity.xslt"));

            if (Directory.Exists(Path.Combine(path, @"Generated\TemplateHelperTest")))
                Directory.Delete(Path.Combine(path, @"Generated\TemplateHelperTest"), true);
            Directory.CreateDirectory(Path.Combine(path, @"Generated\TemplateHelperTest"));

            string outputFile = Path.Combine(path, @"Generated\TemplateHelperTest\LP.cs");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            TemplateHelper.Render(node, trans, outputFile);

            string[] files = Directory.GetFiles(Path.Combine(path, @"Generated\TemplateHelperTest"), "*.cs");
            Assert.AreEqual(1, files.Length);
            Assert.AreEqual(outputFile, files[0]);
        }
    }
}
