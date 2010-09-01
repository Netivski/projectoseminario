using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Context;
using System.IO;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for Transform
    /// </summary>
    [TestClass]
    public class TransformTest
    {
        public TransformTest(){}

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
        }
        
        [TestMethod]
        public void transformNotNull()
        {
            Transform t = new Transform();
            Assert.IsNotNull(t);
        }
        [TestMethod]
        public void canGetXslCompiledTransform()
        {
            Transform t = new Transform();
            XslCompiledTransform trans = t.GetTemplateFile("Entity");
            Assert.IsNotNull(trans);
        }
    }
}
