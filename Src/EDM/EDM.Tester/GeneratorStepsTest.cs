using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Engine.Step;
using EDM.Generator.Context;
using EDM.Generator.Utils.XML;
using System.Xml;
using System.IO;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for GeneratorStepsTest
    /// </summary>
    [TestClass]
    public class GeneratorStepsTest
    {
        private static GeneratorSteps steps;
        private static string outputPath;
        private static string edmFilePath;
        private static GeneratorContext context;
        private static ThreeDXPath xPath;

        public GeneratorStepsTest()
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

        [ClassInitialize]
        public static void Init(TestContext ctx)
        {
            xPath = new ThreeDXPath();
            outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated\GeneratorStepsTest");
            edmFilePath = Path.Combine(outputPath, @"..\..\3D.xml");            

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);            
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Entity\Data"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\Base"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Entity\Domain"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Services\Base"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.UnitTest"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Ws\Base"));

            context = new GeneratorContext();
            context.SetThreeDFile(edmFilePath);
            context.SetOutput(outputPath, "TestNameSpace");
            context.SetTransform();

            steps = new GeneratorSteps();

            steps.Generate(context);
        }

        [TestMethod]
        public void DidGenerateAnyFiles()
        {
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Entity\Data"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\Base"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Entity\Domain"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Services\Base"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Services"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.UnitTest"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Ws\Base"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Ws"))).GetFiles().Length > 0);
        }
        [TestMethod]
        public void DidGenerateAllUserTypeFiles()
        {
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base\BaseUserTypeMetadata.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Rtti\UserTypeMetadata.cs")));
        }
        [TestMethod]
        public void DidGenerateAllEntityDomainFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Entity\Domain\", node.Attributes["name"].Value, "Domain.cs"))));
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Entity\Domain\", node.Attributes["name"].Value, ".hbm.xml"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Entity\", node.Attributes["name"].Value, ".cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityDataFiles()
        {
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\DaoFactory.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\DaoFactoryPartial.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\DAOImplementation.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\DAOImplementationPartial.cs")));
        }
        [TestMethod]
        public void DidGenerateAllEntityDataInterfacesBaseFiles()
        {
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\Base\IDaoFactoryBase.cs")));
        }
        [TestMethod]
        public void DidGenerateAllEntityDataInterfacesFiles()
        {
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\IDaoFactory.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\IDaoInterface.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(outputPath, @"TestNameSpace.Entity\DataInterfaces\IDaoInterfacePartial.cs")));
        }
        [TestMethod]
        public void DidGenerateAllEntityBaseServiceFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Services\Base\", node.Attributes["name"].Value, "BaseService.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityServicesFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Services\", node.Attributes["name"].Value, "Service.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllBPBaseServicesFiles()
        {
            XmlNodeList BPList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Component);
            foreach (XmlNode node in BPList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Services\Base\", node.Attributes["name"].Value, "BaseService.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllBPServicesFiles()
        {
            XmlNodeList BPList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Component);
            foreach (XmlNode node in BPList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Services\", node.Attributes["name"].Value, "Service.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityWsBaseFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\Base\", node.Attributes["name"].Value, "BaseWs.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityWsFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Entity);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\", node.Attributes["name"].Value, "Ws.asmx"))));
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\", node.Attributes["name"].Value, "Ws.asmx.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllBPWsBaseFiles()
        {
            XmlNodeList BPList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Component);
            foreach (XmlNode node in BPList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\Base\", node.Attributes["name"].Value, "BaseWs.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllBPWsFiles()
        {
            XmlNodeList BPList = Get.GetNodeList(context.ThreeDFile.Content, xPath.Component);
            foreach (XmlNode node in BPList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\", node.Attributes["name"].Value, "Ws.asmx"))));
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.Ws\", node.Attributes["name"].Value, "Ws.asmx.cs"))));
            }
        }
        [TestMethod]
        public void DidGenerateAllEntityTestFiles()
        {
            XmlNodeList entitiesList = Get.GetNodeList(context.ThreeDFile.Content, xPath.EntityNotAbstract);
            foreach (XmlNode node in entitiesList)
            {
                Assert.IsTrue(File.Exists(Path.Combine(outputPath, string.Concat(@"TestNameSpace.UnitTest\", node.Attributes["name"].Value, "Test.cs"))));
            }
        }
    }
}
