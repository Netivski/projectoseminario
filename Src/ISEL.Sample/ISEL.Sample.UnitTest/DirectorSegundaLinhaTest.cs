
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class DirectorSegundaLinhaTest
      {
        private static DirectorSegundaLinha target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new DirectorSegundaLinha();
        }
        
        [TestMethod()]
        public void DirectorSegundaLinhaConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a DirectorSegundaLinha.");
        }
        
        [TestMethod()]
        public void isValidDirectorSegundaLinhaTest()
        {
          target = new DirectorSegundaLinha();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  