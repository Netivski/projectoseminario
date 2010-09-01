using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Engine.Step;
using System.IO;
using EDM.Generator.Utils;
using EDM.Generator.Utils.XML;
using EDM.Generator.Context;
using System.Xml;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for GEneratedFIleInfoTest
    /// </summary>
    [TestClass]
    public class GeneratedFIleInfoTest
    {
        private static GeneratedFileInfo file;
        private static string outputPath;
        private static string edmFilePath;
        private static string xsltPath;
        private static GeneratorContext context;
        private static XmlDocument doc;
        private static EDMXPath xPath;

        public GeneratedFIleInfoTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
            outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated\GeneratedFileInfoStepTest");
            edmFilePath = Path.Combine(outputPath, @"..\..\3D.xml");
            xsltPath = Path.Combine(outputPath, @"..\..\XSLT");
            doc = new XmlDocument();
            xPath = new EDMXPath();

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"));

            context = new GeneratorContext();
            context.SetEDMFile(edmFilePath);
            context.SetOutput(outputPath, "TestNameSpace");
            context.SetTransform(xsltPath);
        }

        [TestMethod]
        public void isItNull()
        {
            file = new GeneratedFileInfo("BaseTypes", Path.Combine(context.Output.RttiBasePath, "BaseUserTypeMetadata.cs"), context.EDMFile.XPath.UserTypes, true);
            Assert.IsNotNull(file);
        }
        [TestMethod]
        public void DidGenerateFile()
        {
            file = new GeneratedFileInfo("BaseTypes", Path.Combine(context.Output.RttiBasePath, "BaseUserTypeMetadata.cs"), context.EDMFile.XPath.UserTypes, true);

            XmlNodeList list = context.EDMFile.Content.SelectNodes(file.XPath);
            foreach (XmlNode node in list)
            {
                string outputFile = file.GetOutputFile(Get.GetAttributeValue(context.EDMFile.Content, node, "generatedFileName"));
                TemplateHelper.Render(node, context.Transform.GetTemplateFile(file.TemplateName), outputFile);
            }

            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"))).GetFiles().Length > 0);
        }
    }
}
