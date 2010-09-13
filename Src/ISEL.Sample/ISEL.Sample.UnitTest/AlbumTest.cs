
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class AlbumTest
      {
        private static Album target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Album();
        }
        
        [TestMethod()]
        public void AlbumConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Album.");
        }
        
        [TestMethod()]
        public void isValidAlbumTest()
        {
          target = new Album();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  