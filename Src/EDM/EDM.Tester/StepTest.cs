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
    /// Summary description for StepTest
    /// </summary>
    [TestClass]
    public class StepTest
    {
        private static Step step;
        private static string outputPath;
        private static string edmFilePath;
        private static GeneratorContext context;
        private static XmlDocument doc;

        public StepTest()
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
        public static void Init(TestContext ctx)
        {
            outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated\StepTest");
            edmFilePath = Path.Combine(outputPath, @"..\..\3D.xml");
            doc = new XmlDocument();

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"));

            context = new GeneratorContext();
            context.SetThreeDFile(edmFilePath);
            context.SetOutput(outputPath, "TestNameSpace");
            context.SetTransform();
        }

        [TestMethod]
        public void IsStepNull()
        {
            step = new Step("BaseTypes", Path.Combine(context.Output.RttiBasePath, "BaseUserTypeMetadata.cs"), context.ThreeDFile.XPath.UserTypes, true);
            Assert.IsNotNull(step);
        }
        [TestMethod]
        public void DidStepGenerateFile()
        {
            step = new Step("BaseTypes", Path.Combine(context.Output.RttiBasePath, "BaseUserTypeMetadata.cs"), context.ThreeDFile.XPath.UserTypes, true);

            XmlNodeList list = context.ThreeDFile.Content.SelectNodes(step.XPath);
            foreach (XmlNode node in list)
            {
                string outputFile = step.GetOutputFile(Get.GetAttributeValue(context.ThreeDFile.Content, node, "generatedFileName"));
                step.Generate(context);
            }

            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"))).GetFiles().Length > 0);            
        }
    }
}
