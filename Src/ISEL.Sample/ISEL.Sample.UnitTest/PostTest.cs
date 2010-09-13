
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class PostTest
      {
        private static Post target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Post();
        }
        
        [TestMethod()]
        public void PostConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Post.");
        }
        
        [TestMethod()]
        public void isValidPostTest()
        {
          target = new Post();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  