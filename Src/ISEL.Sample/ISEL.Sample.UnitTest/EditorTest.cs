
    using System;
    using EDM.FoundationClasses.Entity;
    using EDM.FoundationClasses.FoundationType;
    using EDM.FoundationClasses.Persistence.Core;
    using ISEL.Sample.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace ISEL.Sample.UnitTest
    {
      [TestClass()]
      public class EditorTest
      {
        private static Editor target;
        
        [ClassInitialize]
        public static void initTest(TestContext ctx)
        {
          target = new Editor();
        }
        
        [TestMethod()]
        public void EditorConstructorTest()
        {
          Assert.IsNotNull(target, "Unable to instanciate a Editor.");
        }
        
        [TestMethod()]
        public void isValidEditorTest()
        {
          target = new Editor();
          Assert.IsTrue(target.IsValid(), "IsValid unexpectadely returned false.");
        }
     }
  }
  