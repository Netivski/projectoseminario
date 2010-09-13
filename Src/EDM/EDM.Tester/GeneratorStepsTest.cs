using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Engine.Step;
using EDM.Generator.Context;
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
        private static XmlDocument doc;

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
            outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\Generated\GeneratorStepsTest");
            edmFilePath = Path.Combine(outputPath, @"..\..\3D.xml");
            doc = new XmlDocument();

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);            
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"));
            Directory.CreateDirectory(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\Base"));
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
        }

        [TestMethod]
        public void IsNotNull()
        {
            Assert.IsNotNull(steps);
        }
        [TestMethod]
        public void DidGenerateAllFiles()
        {
            steps.Generate(context);

            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti\Base"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Rtti"))).GetFiles().Length > 0);
            Assert.IsTrue((new DirectoryInfo(Path.Combine(outputPath, @"TestNameSpace.Entity\Data\Base"))).GetFiles().Length > 0);
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
    }
}
