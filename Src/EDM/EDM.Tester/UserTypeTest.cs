using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Exception;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for UserTypeTest
    /// </summary>
    [TestClass]
    public class UserTypeTest
    {
        private static IUserType<int> intType;

        public UserTypeTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void NoNegativeLengthAllowed()
        {
            //Verifies that no negative length argument is allowed
            try
            {
                intType = new UserType<int>(-4, 0, 0, null, null, null, null, null, null, null, null, null);
                Assert.Fail("Allow negative length argument in UserType constructor");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Argument length can't be negative!", ex.Message);
            }
        }

        [TestMethod]
        public void NoNegativeMinLength()
        {
            //Verifies that no negative minLength argument is allowed
            try
            {
                intType = new UserType<int>(4, -2, 0, null, null, null, null, null, null, null, null, null);
                Assert.Fail("Allow negative minLength argument in UserType constructor");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Argument minLength can't be negative!", ex.Message);
            }
        }

        [TestMethod]
        public void NoNegativeMaxLength()
        {
            //Verifies that no negative maxLength argument is allowed
            try
            {
                intType = new UserType<int>(4, 2, -2, null, null, null, null, null, null, null, null, null);
                Assert.Fail("Allow negative maxLength argument in UserType constructor");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Argument maxLength can't be negative!", ex.Message);
            }
        }

        [TestMethod]
        public void NoNegativeTotalDigits()
        {
            //Verifies that no negative totalDigits argument is allowed
            try
            {
                intType = new UserType<int>(4, 2, 0, null, null, null, null, null, null, null, -2, null);
                Assert.Fail("Allow negative totalDigits argument in UserType constructor");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Argument totalDigits can't be negative!", ex.Message);
            }
        }

        [TestMethod]
        public void NoNegativeFractionDigits()
        {
            //Verifies that no negative fractionDigits argument is allowed
            try
            {
                intType = new UserType<int>(4, 2, 0, null, null, null, null, null, null, null, 4, -2);
                Assert.Fail("Allow negative fractionDigits argument in UserType constructor");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Argument fractionDigits can't be negative!", ex.Message);
            }
        }

        [TestMethod]
        public void DoesTotalDigitsGetsDefaultValue()
        {
            intType = new UserType<int>(0, 0, 0, null, null, null, null, null, null, null, null, null);

            //TotalDigits default value (0)?
            Assert.AreEqual(0, intType.TotalDigits.Value);
        }

        [TestMethod]
        public void DoesFractionDigitsGetsDefaultValue()
        {
            intType = new UserType<int>(0, 0, 0, null, null, null, null, null, null, null, null, null);

            //FractionDigits default value (0)?
            Assert.AreEqual(0, intType.FractionDigits.Value);
        }

        [TestMethod]
        public void DoesWhiteSpaceEnumGetsDefaultValue()
        {
            intType = new UserType<int>(0, 0, 0, null, null, null, null, null, null, null, null, null);
            
            //WhiteSpace has value?
            Assert.AreEqual(new WhiteSpaceEnum(), intType.WhiteSpace);
        }
    }
}
