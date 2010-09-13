
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class TurmaTest
      {
        private static Turma target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Turma();
        }
        
        [TestMethod()]
        public void TurmaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Turma.");
        }
        
        [TestMethod()]
        public void isValidTurmaTest()
        {
          target = new Turma();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  