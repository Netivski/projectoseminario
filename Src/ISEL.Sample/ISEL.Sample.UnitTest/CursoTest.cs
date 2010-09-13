
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class CursoTest
      {
        private static Curso target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Curso();
        }
        
        [TestMethod()]
        public void CursoConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Curso.");
        }
        
        [TestMethod()]
        public void isValidCursoTest()
        {
          target = new Curso();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  