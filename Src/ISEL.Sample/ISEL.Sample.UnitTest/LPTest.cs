
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class LPTest
      {
        private static LP target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new LP();
        }
        
        [TestMethod()]
        public void LPConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a LP.");
        }
        
        [TestMethod()]
        public void isValidLPTest()
        {
          target = new LP();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  