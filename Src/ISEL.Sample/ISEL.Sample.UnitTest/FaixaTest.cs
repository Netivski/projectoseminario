
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class FaixaTest
      {
        private static Faixa target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Faixa();
        }
        
        [TestMethod()]
        public void FaixaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Faixa.");
        }
        
        [TestMethod()]
        public void isValidFaixaTest()
        {
          target = new Faixa();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  