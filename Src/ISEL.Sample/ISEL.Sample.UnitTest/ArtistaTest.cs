
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class ArtistaTest
      {
        private static Artista target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Artista();
        }
        
        [TestMethod()]
        public void ArtistaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Artista.");
        }
        
        [TestMethod()]
        public void isValidArtistaTest()
        {
          target = new Artista();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  