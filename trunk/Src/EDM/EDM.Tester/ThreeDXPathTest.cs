using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.Generator.Context;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for EDMXPathTest
    /// </summary>
    [TestClass]
    public class ThreeDXPathTest
    {
        private static ThreeDXPath xpath;
        public ThreeDXPathTest(){}

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
            xpath = new ThreeDXPath();
        }

        [TestMethod]
        public void EDMXPathNotNull()
        {
            Assert.IsNotNull(xpath);
        }
        [TestMethod]
        public void CanGetRoot()
        {
            Assert.AreEqual(xpath.Root, "/");
        }
        [TestMethod]
        public void CanGetSolution()
        {
            Assert.AreEqual(xpath.Solution, "/solution");
        }
        [TestMethod]
        public void CanGetUserTypes()
        {
            Assert.AreEqual(xpath.UserTypes, "/solution/userTypes");
        }
        [TestMethod]
        public void CanGetEntities()
        {
            Assert.AreEqual(xpath.Entities, "/solution/entities");
        }
        [TestMethod]
        public void CanGetEntity()
        {
            Assert.AreEqual(xpath.Entity, "/solution/entities/entity");
        }
        [TestMethod]
        public void CanGetEntityFields()
        {
            Assert.AreEqual(xpath.EntityFields, "./fields");
        }
        [TestMethod]
        public void CanGetEntitiesRelations()
        {
            Assert.AreEqual(xpath.EntitiesRelations, "/solution/entities/relations");
        }
        [TestMethod]
        public void CanGetEntitiesRelation()
        {
            Assert.AreEqual(xpath.EntitiesRelation, "/solution/entities/relations/relation");
        }
        [TestMethod]
        public void CanGetEntitiesRelationOneToMany()
        {
            Assert.AreEqual(xpath.EntitiesRelationOneToMany, "/solution/entities/relations/relation[@type = 'OneToMany']");
        }
        [TestMethod]
        public void CanGetEntitiesRelationManyToOne()
        {
            Assert.AreEqual(xpath.EntitiesRelationManyToOne, "/solution/entities/relations/relation[@type = 'ManyToOne']");
        }
        [TestMethod]
        public void CanGetOneToOneRelation()
        {
            Assert.AreEqual(xpath.OneToOneRelation, "//oneToOne");
        }
        [TestMethod]
        public void CanGetOneToManyRelation()
        {
            Assert.AreEqual(xpath.OneToManyRelation, "//oneToMany");
        }
        [TestMethod]
        public void CanGetManyToOneRelation()
        {
            Assert.AreEqual(xpath.ManyOneToRelation, "//manyToOne");
        }
        [TestMethod]
        public void CanGetManyToManyRelation()
        {
            Assert.AreEqual(xpath.ManyToManyRelation, "//manyToMany");
        }
        [TestMethod]
        public void CanGetBusinessProcesses()
        {
            Assert.AreEqual(xpath.BusinessProcesses, "/solution/businessProcesses");
        }
        [TestMethod]
        public void CanGetComponent()
        {
            Assert.AreEqual(xpath.Component, "/solution/businessProcesses/component");
        }
        [TestMethod]
        public void CanGetBusinessProcess()
        {
            Assert.AreEqual(xpath.BusinessProcess, "/solution/businessProcesses/component/businessProcess");
        }
    }
}
