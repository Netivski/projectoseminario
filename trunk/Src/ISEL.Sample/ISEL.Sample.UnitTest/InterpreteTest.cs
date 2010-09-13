
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class InterpreteTest
      {
        private static Interprete target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Interprete();
        }
        
        [TestMethod()]
        public void InterpreteConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Interprete.");
        }
        
        [TestMethod()]
        public void isValidInterpreteTest()
        {
          target = new Interprete();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  