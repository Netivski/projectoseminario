
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class ClienteTest
      {
        private static Cliente target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Cliente();
        }
        
        [TestMethod()]
        public void ClienteConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Cliente.");
        }
        
        [TestMethod()]
        public void isValidClienteTest()
        {
          target = new Cliente();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  