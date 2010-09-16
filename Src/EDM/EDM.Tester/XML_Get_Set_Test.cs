using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Utils.XML;
using System.Xml;

namespace EDM.Tester
{
    /// <summary>
    /// Test Class for static EDM.Generator.Utils.XML.Get and EDM.Generator.Utils.XML.Set
    /// </summary>
    [TestClass]
    public class XML_Get_Set_Test
    {
        private string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Tester\SampleFiles\3D.xml");
        private XmlDocument _doc;
        private XmlTextReader _reader;
        
        public XML_Get_Set_Test()
        {
            _doc = new XmlDocument();
            _reader = new XmlTextReader(filePath);
            _doc.Load(_reader);
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
        
        [TestMethod]
        public void CanGetNodeList()
        {
            XmlNodeList list = Get.GetNodeList(_doc, "/solution/*");
            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void CanGetNode()
        {
            XmlNode node = Get.GetNode(_doc, "/solution/entities/*[@name = 'LP']");
            Assert.IsNotNull(node);
        }
        [TestMethod]
        public void CanGetAttributeValueFromNode()
        {
            XmlNode node = Get.GetNode(_doc, "/solution/entities/*[@name = 'LP']");
            String value = Get.GetAttributeValue(_doc, node, "baseEntity");
            Assert.AreEqual("Album", value);
        }
        [TestMethod]
        public void CanGetAttributeValueFromXPath()
        {
            String value = Get.GetAttributeValue(_doc, "/solution/entities/*[@name = 'LP']", "baseEntity");
            Assert.AreEqual("Album", value);
        }
        [TestMethod]
        public void CanSetAttributeValue()
        {
            String beforeValue = Get.GetAttributeValue(_doc, "/solution/entities/*[@name = 'LP']", "baseEntity");
            Set.SetAttributeValue(_doc, "/solution/entities/*[@name = 'LP']", "baseEntity", "newValue");
            String afterValue = Get.GetAttributeValue(_doc, "/solution/entities/*[@name = 'LP']", "baseEntity");
            Assert.AreNotEqual(afterValue, beforeValue);
            Assert.AreEqual("newValue", afterValue);
        }
        [TestMethod]
        public void CanAddAttributeByXPath()
        {
            XmlNode node = Get.GetNode(_doc, "/solution/entities/*[@name = 'LP']");
            int nodeCount = node.Attributes.Count;            
            Set.AddAttribute(_doc, "/solution/entities/*[@name = 'LP']", "newAttributeName", "value");            
            Assert.AreEqual(node.Attributes.Count, nodeCount + 1);
            Assert.AreEqual(node.Attributes[nodeCount].Value.ToString(), "value");
        }
        [TestMethod]
        public void CanAddAttributeByNode()
        {
            XmlNode node = Get.GetNode(_doc, "/solution/entities/*[@name = 'LP']");
            int nodeCount = node.Attributes.Count;            
            Set.AddAttribute(_doc, node, "newAttributeName", "value");            
            Assert.AreEqual(node.Attributes.Count, nodeCount + 1);
            Assert.AreEqual(node.Attributes[nodeCount].Value.ToString(), "value");
        }
    }
}
