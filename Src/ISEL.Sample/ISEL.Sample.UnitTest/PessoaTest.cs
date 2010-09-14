
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class PessoaTest
      {
        private static Pessoa target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Pessoa();
        }
        
        [TestMethod()]
        public void PessoaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Pessoa.");
        }
        
        [TestMethod()]
        public void isValidPessoaTest()
        {
          target = new Pessoa();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  