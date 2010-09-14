
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class ManagerTest
      {
        private static Manager target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Manager();
        }
        
        [TestMethod()]
        public void ManagerConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Manager.");
        }
        
        [TestMethod()]
        public void isValidManagerTest()
        {
          target = new Manager();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  