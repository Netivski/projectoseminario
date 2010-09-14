
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class EmpregadoTest
      {
        private static Empregado target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Empregado();
        }
        
        [TestMethod()]
        public void EmpregadoConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Empregado.");
        }
        
        [TestMethod()]
        public void isValidEmpregadoTest()
        {
          target = new Empregado();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  