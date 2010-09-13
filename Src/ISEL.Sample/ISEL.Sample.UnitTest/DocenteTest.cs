
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class DocenteTest
      {
        private static Docente target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Docente();
        }
        
        [TestMethod()]
        public void DocenteConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Docente.");
        }
        
        [TestMethod()]
        public void isValidDocenteTest()
        {
          target = new Docente();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  