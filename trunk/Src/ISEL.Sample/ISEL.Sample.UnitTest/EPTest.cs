
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class EPTest
      {
        private static EP target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new EP();
        }
        
        [TestMethod()]
        public void EPConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a EP.");
        }
        
        [TestMethod()]
        public void isValidEPTest()
        {
          target = new EP();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  