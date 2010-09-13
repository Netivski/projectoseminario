
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class PersonTest
      {
        private static Person target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Person();
        }
        
        [TestMethod()]
        public void PersonConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Person.");
        }
        
        [TestMethod()]
        public void isValidPersonTest()
        {
          target = new Person();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  