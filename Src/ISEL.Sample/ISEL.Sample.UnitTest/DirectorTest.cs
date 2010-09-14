
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class DirectorTest
      {
        private static Director target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Director();
        }
        
        [TestMethod()]
        public void DirectorConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Director.");
        }
        
        [TestMethod()]
        public void isValidDirectorTest()
        {
          target = new Director();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  