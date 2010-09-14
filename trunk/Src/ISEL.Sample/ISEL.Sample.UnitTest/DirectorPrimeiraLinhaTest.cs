
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class DirectorPrimeiraLinhaTest
      {
        private static DirectorPrimeiraLinha target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new DirectorPrimeiraLinha();
        }
        
        [TestMethod()]
        public void DirectorPrimeiraLinhaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a DirectorPrimeiraLinha.");
        }
        
        [TestMethod()]
        public void isValidDirectorPrimeiraLinhaTest()
        {
          target = new DirectorPrimeiraLinha();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  