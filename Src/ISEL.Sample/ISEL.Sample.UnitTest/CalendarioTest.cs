
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class CalendarioTest
      {
        private static Calendario target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Calendario();
        }
        
        [TestMethod()]
        public void CalendarioConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Calendario.");
        }
        
        [TestMethod()]
        public void isValidCalendarioTest()
        {
          target = new Calendario();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  