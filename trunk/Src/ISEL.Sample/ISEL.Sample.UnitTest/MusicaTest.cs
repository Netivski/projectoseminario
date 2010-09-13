
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class MusicaTest
      {
        private static Musica target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Musica();
        }
        
        [TestMethod()]
        public void MusicaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Musica.");
        }
        
        [TestMethod()]
        public void isValidMusicaTest()
        {
          target = new Musica();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  