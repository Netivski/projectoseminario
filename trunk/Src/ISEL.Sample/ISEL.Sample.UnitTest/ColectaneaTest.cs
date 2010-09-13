
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class ColectaneaTest
      {
        private static Colectanea target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Colectanea();
        }
        
        [TestMethod()]
        public void ColectaneaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Colectanea.");
        }
        
        [TestMethod()]
        public void isValidColectaneaTest()
        {
          target = new Colectanea();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  