
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class AnoTest
      {
        private static Ano target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Ano();
        }
        
        [TestMethod()]
        public void AnoConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Ano.");
        }
        
        [TestMethod()]
        public void isValidAnoTest()
        {
          target = new Ano();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  