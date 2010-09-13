
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class LojaTest
      {
        private static Loja target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Loja();
        }
        
        [TestMethod()]
        public void LojaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Loja.");
        }
        
        [TestMethod()]
        public void isValidLojaTest()
        {
          target = new Loja();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  