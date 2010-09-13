
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class BlogTest
      {
        private static Blog target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Blog();
        }
        
        [TestMethod()]
        public void BlogConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Blog.");
        }
        
        [TestMethod()]
        public void isValidBlogTest()
        {
          target = new Blog();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  