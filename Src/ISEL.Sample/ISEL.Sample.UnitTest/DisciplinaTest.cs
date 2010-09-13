
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class DisciplinaTest
      {
        private static Disciplina target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Disciplina();
        }
        
        [TestMethod()]
        public void DisciplinaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Disciplina.");
        }
        
        [TestMethod()]
        public void isValidDisciplinaTest()
        {
          target = new Disciplina();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  