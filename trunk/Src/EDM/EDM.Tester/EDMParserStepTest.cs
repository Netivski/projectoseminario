﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Engine.Step;
using EDM.Generator.Context;
using EDM.Generator.Utils.XML;
using EDM.Generator.Context;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for EDMParserStepTest
    /// </summary>
    [TestClass]
    public class EDMParserStepTest
    {
        private static string outputPath;
        private static string edmFilePath;
        private static string xsltPath;
        private static AbstractStep step;
        private static GeneratorContext context;
        private static XmlDocument doc;
        private static EDMXPath xPath;


        public EDMParserStepTest(){}

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

        private void generate()
        {
            step.GenerateStep(context);
            context.EDMFile.Content.Save(Path.Combine(outputPath, "GeneratedXml.xml"));
            doc.Load(Path.Combine(outputPath, "GeneratedXml.xml"));
        }

        [ClassInitialize]
        public static void init(TestContext ctx)
        {
            outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated\EDMParserStepTest");
            edmFilePath = Path.Combine(outputPath, @"..\..\3D.xml");
            xsltPath = Path.Combine(outputPath, @"..\..\XSLT");
            doc = new XmlDocument();
            xPath = new EDMXPath();

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);

            step = new EDMParserStep();
            context = new GeneratorContext();
            context.SetEDMFile(edmFilePath);
            context.SetOutput(outputPath, "TestNameSpace");
            context.SetTransform(xsltPath);
        }

        [TestMethod]
        public void StepIsNotNull()
        {
            Assert.IsNotNull(step);
        }
        [TestMethod]
        public void CanStepGenerate()
        {
            generate();
            Assert.AreNotEqual(0, doc.ChildNodes.Count);
        }        
        [TestMethod]
        public void DidAddEDMTypeAttributeToFields()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, string.Concat(xPath.Entity, "/fields/field"));
            foreach (XmlNode node in list)
            {   
                Assert.IsNotNull(Get.GetAttributeValue(doc, node, "edmType"));
            }
        }
        [TestMethod]
        public void DidAddNameSpaceAttributeToSolution()
        {
            generate();
            XmlNode node = Get.GetNode(doc, xPath.Solution);
            if (node == null)
                Assert.Fail();
            Assert.IsNotNull(node.Attributes["nameSpace"]);
            Assert.AreEqual(context.EDMFile.NameSpace, node.Attributes["nameSpace"].Value);
        }
        
        [TestMethod]
        public void DidAddAssemblyNameAttributeToUserType()
        {
            generate();
            XmlNode node = Get.GetNode(doc, xPath.UserTypes);            
            Assert.IsNotNull(node.Attributes["assemblyName"]);
            Assert.AreEqual(string.Concat(context.EDMFile.BaseName, ".", "Rtti"), node.Attributes["assemblyName"].Value);
        }
        [TestMethod]
        public void DidAddNameSpaceAttributeToUserType()
        {
            generate();
            XmlNode node = Get.GetNode(doc, xPath.UserTypes);
            Assert.IsNotNull(node.Attributes["nameSpace"]);
            Assert.AreEqual(string.Concat(context.EDMFile.NameSpace, ".Rtti"), node.Attributes["nameSpace"].Value);
        }
        [TestMethod]
        public void DidAddGeneratedFileNameAttributeToUserType()
        {
            generate();
            XmlNode node = Get.GetNode(doc, xPath.UserTypes);
            Assert.IsNotNull(node.Attributes["generatedFileName"]);
            Assert.AreEqual(string.Empty, node.Attributes["generatedFileName"].Value);
        }
        [TestMethod]

        public void DidAddNameSpaceAttributeToEntities()
        {
            generate();
            XmlNode node = Get.GetNode(doc, xPath.Entities);            
            Assert.IsNotNull(node.Attributes["nameSpace"]);
            Assert.AreEqual(string.Concat(context.EDMFile.NameSpace, ".Entity"), node.Attributes["nameSpace"].Value);
        }
        [TestMethod]
        public void DidAddAssemblyNameAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["assemblyName"]);
                Assert.AreEqual(string.Concat(context.EDMFile.BaseName, ".Entity"), node.Attributes["assemblyName"].Value);
            }
        }
        [TestMethod]
        public void DidAddNameSpaceAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["nameSpace"]);
                string expected = string.Format("{0}.{1}.{2}", context.EDMFile.NameSpace, "Entity", node.Attributes["name"].Value);
                Assert.AreEqual(expected, node.Attributes["nameSpace"].Value);
            }
        }
        [TestMethod]
        public void DidAddBaseNameSpaceAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["baseNameSpace"]);
                Assert.AreEqual(string.Format("{0}.{1}", context.EDMFile.NameSpace, "Entity"), node.Attributes["baseNameSpace"].Value);
            }
        }
        [TestMethod]
        public void DidAddRttiNameSpaceAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["rttiNameSpace"]);
                Assert.AreEqual(string.Format("{0}.{1}", context.EDMFile.NameSpace, "Rtti"), node.Attributes["rttiNameSpace"].Value);
            }
        }
        [TestMethod]
        public void DidAddGeneratedFileNameAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["generatedFileName"]);
                Assert.AreEqual(node.Attributes["name"].Value, node.Attributes["generatedFileName"].Value);
            }
        }
        [TestMethod]
        public void DidAddTargetDomainPathAttributeToEntity()
        {
            generate();
            XmlNodeList list = Get.GetNodeList(doc, xPath.Entity);
            foreach (XmlNode node in list)
            {
                Assert.IsNotNull(node.Attributes["targetDomainPath"]);
                Assert.AreEqual(context.Output.EntityDomainPath, node.Attributes["targetDomainPath"].Value);
            }
        }
    }
}
