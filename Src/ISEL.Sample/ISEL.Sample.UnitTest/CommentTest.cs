
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class CommentTest
      {
        private static Comment target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Comment();
        }
        
        [TestMethod()]
        public void CommentConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Comment.");
        }
        
        [TestMethod()]
        public void isValidCommentTest()
        {
          target = new Comment();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  