using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDM.FoundationClasses.FoundationType;

namespace EDM.Tester
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        private static IUserType<long> _longType;
        private static IUserType<int> _intType;
        private static IUserType<short> _shortType;
        private static IUserType<byte> _byteType;
        private static IUserType<decimal> _decimalType;
        private static IUserType<float> _floatType;
        private static IUserType<double> _doubleType;
        private static IUserType<string> _stringType;
        private static IUserType<DateTime> _dateTimeType;        

        public ValidatorTest()
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
        public void LongTypeValidationTest()
        {
            //long type
            //constraints:
            //  totalDigits
            //  fractionDigits = 0
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //totalDigits
            _longType = new UserType<long>(0, 0, 0, null, null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_longType, 150));
            Assert.IsFalse(Validator.IsValid(_longType, 1500));

            //pattern
            _longType = new UserType<long>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_longType, 123));
            Assert.IsFalse(Validator.IsValid(_longType, 1));
            Assert.IsTrue(Validator.IsValid(_longType, 23));
            
            //enumeration
            Assert.IsTrue(Validator.IsValid(_longType, 987));
            _longType = new UserType<long>(0, 0, 0, "[0-9]{3}", new List<long>{ 123, 234, 345, 456 }, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_longType, 345));
            //Assert.IsFalse(Validator.IsValid(_longType, 987));
            
            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_longType, 987));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<long>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _longType = new UserType<long>(0, 0, 0, "\\b\\d{2,3}", null, new NullableType<long>(110), null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_longType, 110));
            Assert.IsTrue(Validator.IsValid(_longType, 150));
            Assert.IsFalse(Validator.IsValid(_longType, 109));

            //minExclusive
            _longType = new UserType<long>(0, 0, 0, "\\b\\d{2,3}", null, null, new NullableType<long>(110), null, null, null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_longType, 110));
            Assert.IsTrue(Validator.IsValid(_longType, 111));
            Assert.IsFalse(Validator.IsValid(_longType, 100));

            //maxInclusive
            _longType = new UserType<long>(0, 0, 0, "\\b\\d{2,3}", null, null, null, new NullableType<long>(550), null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_longType, 550));
            Assert.IsTrue(Validator.IsValid(_longType, 549));
            Assert.IsFalse(Validator.IsValid(_longType, 551));

            //maxExclusive
            _longType = new UserType<long>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, new NullableType<long>(550), null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_longType, 550));
            Assert.IsTrue(Validator.IsValid(_longType, 549));
            Assert.IsFalse(Validator.IsValid(_longType, 551));
        }
        [TestMethod]
        public void IntTypeValidationTest()
        {
            //int type
            //constraints:
            //  totalDigits
            //  fractionDigits = 0
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //totalDigits
            _intType = new UserType<int>(0, 0, 0, null, null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_intType, 150));
            Assert.IsFalse(Validator.IsValid(_intType, 1500));

            //pattern
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, null, null, 5, 0);
            Assert.IsTrue(Validator.IsValid(_intType, 123));
            Assert.IsFalse(Validator.IsValid(_intType, 1));
            Assert.IsTrue(Validator.IsValid(_intType, 23));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_intType, 987));
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", new List<int> { 123, 234, 345, 456 }, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_intType, 345));
            //Assert.IsFalse(Validator.IsValid(_intType, 987));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_intType, 987));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<int>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", null, new NullableType<int>(110), null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_intType, 110));
            Assert.IsTrue(Validator.IsValid(_intType, 150));
            Assert.IsFalse(Validator.IsValid(_intType, 109));

            //minExclusive
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", null, null, new NullableType<int>(110), null, null, null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_intType, 110));
            Assert.IsTrue(Validator.IsValid(_intType, 111));
            Assert.IsFalse(Validator.IsValid(_intType, 100));

            //maxInclusive
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", null, null, null, new NullableType<int>(550), null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_intType, 550));
            Assert.IsTrue(Validator.IsValid(_intType, 549));
            Assert.IsFalse(Validator.IsValid(_intType, 551));

            //maxExclusive
            _intType = new UserType<int>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, new NullableType<int>(550), null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_intType, 550));
            Assert.IsTrue(Validator.IsValid(_intType, 549));
            Assert.IsFalse(Validator.IsValid(_intType, 551));
        }
        [TestMethod]
        public void ShortTypeValidationTest()
        {
            //short type
            //constraints:
            //  totalDigits
            //  fractionDigits = 0
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //totalDigits
            _shortType = new UserType<short>(0, 0, 0, null, null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_shortType, 150));
            Assert.IsFalse(Validator.IsValid(_shortType, 1500));

            //pattern
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_shortType, 123));
            Assert.IsFalse(Validator.IsValid(_shortType, 1));
            Assert.IsTrue(Validator.IsValid(_shortType, 23));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_shortType, 987));
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", new List<short> { 123, 234, 345, 456 }, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_shortType, 345));
            //Assert.IsFalse(Validator.IsValid(_shortType, 987));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_shortType, 987));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<short>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", null, new NullableType<short>(110), null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_shortType, 110));
            Assert.IsTrue(Validator.IsValid(_shortType, 150));
            Assert.IsFalse(Validator.IsValid(_shortType, 109));

            //minExclusive
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", null, null, new NullableType<short>(110), null, null, null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_shortType, 110));
            Assert.IsTrue(Validator.IsValid(_shortType, 111));
            Assert.IsFalse(Validator.IsValid(_shortType, 100));

            //maxInclusive
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", null, null, null, new NullableType<short>(550), null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_shortType, 550));
            Assert.IsTrue(Validator.IsValid(_shortType, 549));
            Assert.IsFalse(Validator.IsValid(_shortType, 551));

            //maxExclusive
            _shortType = new UserType<short>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, new NullableType<short>(550), null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_shortType, 550));
            Assert.IsTrue(Validator.IsValid(_shortType, 549));
            Assert.IsFalse(Validator.IsValid(_shortType, 551));
        }
        [TestMethod]
        public void ByteTypeValidationTest()
        {
            //byte type
            //constraints:
            //  totalDigits
            //  fractionDigits = 0
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //totalDigits
            _byteType = new UserType<byte>(0, 0, 0, null, null, null, null, null, null, null, 2, 0);
            Assert.IsTrue(Validator.IsValid(_byteType, 15));
            Assert.IsFalse(Validator.IsValid(_byteType, 101));            

            //pattern
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_byteType, 111));
            Assert.IsFalse(Validator.IsValid(_byteType, 1));
            Assert.IsTrue(Validator.IsValid(_byteType, 23));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_byteType, 115));
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", new List<byte> { 101, 110, 120, 130 }, null, null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_byteType, 110));
            //Assert.IsFalse(Validator.IsValid(_byteType, 115));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_byteType, 987));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<byte>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", null, new NullableType<byte>(110), null, null, null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_byteType, 110));
            Assert.IsTrue(Validator.IsValid(_byteType, 150));
            Assert.IsFalse(Validator.IsValid(_byteType, 109));

            //minExclusive
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", null, null, new NullableType<byte>(110), null, null, null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_byteType, 110));
            Assert.IsTrue(Validator.IsValid(_byteType, 111));
            Assert.IsFalse(Validator.IsValid(_byteType, 100));

            //maxInclusive
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", null, null, null, new NullableType<byte>(110), null, null, 3, 0);
            Assert.IsTrue(Validator.IsValid(_byteType, 110));
            Assert.IsTrue(Validator.IsValid(_byteType, 109));
            Assert.IsFalse(Validator.IsValid(_byteType, 111));

            //maxExclusive
            _byteType = new UserType<byte>(0, 0, 0, "\\b\\d{2,3}", null, null, null, null, new NullableType<byte>(110), null, 3, 0);
            Assert.IsFalse(Validator.IsValid(_byteType, 110));
            Assert.IsTrue(Validator.IsValid(_byteType, 109));
            Assert.IsFalse(Validator.IsValid(_byteType, 111));
        }
        [TestMethod]
        public void DecimalTypeValidationTest()
        {
            //decimal type
            //constraints:
            //  totalDigits
            //  fractionDigits
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //totalDigits
            _decimalType = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, null, 5, 0);
            Assert.IsTrue(Validator.IsValid(_decimalType, 12345));
            Assert.IsFalse(Validator.IsValid(_decimalType, 123456));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.345)));

            //fractionDigits
            _decimalType = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, null, 5, 2);
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.34)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(1.234)));

            //pattern
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, null, null, 5, 2);
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.3)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(13.45)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12)));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.3)));
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", new List<decimal> { new Decimal(12.1), new Decimal(12.2), new Decimal(12.3), new Decimal(12.4) }, null, null, null, null, null, 5, 2);
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.1)));
            //Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.6)));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.6)));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<decimal>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, new NullableType<decimal>(new Decimal(12.3)), null, null, null, null, 5, 2);
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.3)));
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.4)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.2)));

            //minExclusive
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, new NullableType<decimal>(new Decimal(12.3)), null, null, null, 5, 2);
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.3)));
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.4)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.2)));

            //maxInclusive
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, new NullableType<decimal>(new Decimal(12.3)), null, null, 5, 2);
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.3)));
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.2)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.4)));

            //maxExclusive
            _decimalType = new UserType<decimal>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, new NullableType<decimal>(new Decimal(12.3)), null, 5, 2);
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.3)));
            Assert.IsTrue(Validator.IsValid(_decimalType, new Decimal(12.2)));
            Assert.IsFalse(Validator.IsValid(_decimalType, new Decimal(12.4)));
        }
        [TestMethod]
        public void FloatTypeValidationTest()
        {
            //float type
            //constraints:
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive
                        
            //pattern
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_floatType, 12.3f));
            Assert.IsFalse(Validator.IsValid(_floatType, 123.45f));
            Assert.IsFalse(Validator.IsValid(_floatType, 12f));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_floatType, 12.3f));
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", new List<float> { 12.1f, 12.2f, 12.3f, 12.4f }, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_floatType, 12.1f));
            //Assert.IsFalse(Validator.IsValid(_floatType, 12.6f));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_floatType, 12.6f));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<float>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, new NullableType<float>(12.3f), null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_floatType, 12.3f));
            Assert.IsTrue(Validator.IsValid(_floatType, 12.4f));
            Assert.IsFalse(Validator.IsValid(_floatType, 12.2f));

            //minExclusive
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, new NullableType<float>(12.3f), null, null, null, null, null);
            Assert.IsFalse(Validator.IsValid(_floatType, 12.3f));
            Assert.IsTrue(Validator.IsValid(_floatType, 12.4f));
            Assert.IsFalse(Validator.IsValid(_floatType, 12.2f));

            //maxInclusive
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, new NullableType<float>(12.3f), null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_floatType, 12.3f));
            Assert.IsTrue(Validator.IsValid(_floatType, 12.2f));
            Assert.IsFalse(Validator.IsValid(_floatType, 12.4f));

            //maxExclusive
            _floatType = new UserType<float>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, new NullableType<float>(12.3f), null, null, null);
            Assert.IsFalse(Validator.IsValid(_floatType, 12.3f));
            Assert.IsTrue(Validator.IsValid(_floatType, 12.2f));
            Assert.IsFalse(Validator.IsValid(_floatType, 12.4f));
        }
        [TestMethod]
        public void DoubleTypeValidationTest()
        {
            //double type
            //constraints:
            //  pattern
            //  whiteSpace = null
            //  enumeration
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //pattern
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.3));
            Assert.IsFalse(Validator.IsValid(_doubleType, 123.45));
            Assert.IsFalse(Validator.IsValid(_doubleType, 12));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.3));
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", new List<double> { 12.1, 12.2, 12.3, 12.4 }, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.1));
            //Assert.IsFalse(Validator.IsValid(_doubleType, 12.6));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_doubleType, 12.6));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<double>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, new NullableType<double>(12.3), null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.3));
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.4));
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.2));

            //minExclusive
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, new NullableType<double>(12.3), null, null, null, null, null);
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.3));
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.4));
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.2));

            //maxInclusive
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, new NullableType<double>(12.3), null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.3));
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.2));
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.4));

            //maxExclusive
            _doubleType = new UserType<double>(0, 0, 0, "\\b\\d{2,3},\\d{1}\\b", null, null, null, null, new NullableType<double>(12.3), null, null, null);
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.3));
            Assert.IsTrue(Validator.IsValid(_doubleType, 12.2));
            Assert.IsFalse(Validator.IsValid(_doubleType, 12.4));
        }
        [TestMethod]
        public void StringTypeValidationTest()
        {
            //string type
            //constraints:
            //  length
            //  minLength
            //  maxLength
            //  pattern
            //  enumeration
            //  whiteSpace

            //length
            _stringType = new UserType<String>(5, 0, 0, null, null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_stringType, "Abc"));
            Assert.IsFalse(Validator.IsValid(_stringType, "Abcdef"));

            //minLength
            _stringType = new UserType<String>(5, 3, 0, null, null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_stringType, "Abc"));
            Assert.IsFalse(Validator.IsValid(_stringType, "Ab"));

            //maxLength
            _stringType = new UserType<String>(5, 3, 3, null, null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_stringType, "Abc"));
            Assert.IsFalse(Validator.IsValid(_stringType, "Ab"));
            Assert.IsFalse(Validator.IsValid(_stringType, "Abcd"));


            //pattern
            _stringType = new UserType<string>(30, 5, 30, @"1\+1=2", null, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_stringType, "1+1=2"));
            Assert.IsTrue(Validator.IsValid(_stringType, "1+1=2 e 1+2=3"));
            Assert.IsFalse(Validator.IsValid(_stringType, "123"));

            //enumeration
            Assert.IsTrue(Validator.IsValid(_stringType, "1+1=2 e 1+2=3"));
            _stringType = new UserType<String>(0, 0, 0, @"1\+1=2", new List<String> { "1*1=2", "1-1=2", "1+1=2", "12.4" }, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_stringType, "1+1=2"));
            //Assert.IsFalse(Validator.IsValid(_stringType, "1+1=2 e 1+2=3"));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_stringType, "1+1=2 e 1+2=3"));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<string>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //WhiteSpace

            _stringType = new UserType<string>(30, 5, 30, @"1\+1=2 2", null, null, null, null, null, WhiteSpaceEnum.Collapse, null, null);
            //Assert.IsTrue(Validator.IsValid(_stringType, "1+1=2  2"));

            //Qual deveria ser o comportamento quando especificado o WhiteSpaceEnum????
            //  nunca está a ser utilizado em Validator
        }
        [TestMethod]
        public void DateTimeTypeValidationTest()
        {
            //dateTime type
            //constraints:
            //  pattern
            //  enumeration
            //  whiteSpace
            //  maxInclusive
            //  minInclusive
            //  maxExclusive
            //  minExclusive

            //TODO
            //pattern
            //_dateTimeType = new UserType<DateTime>(0, 0, 0, "", null, null, null, null, null, null, null, null);
            //Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            

            //enumeration            
            _dateTimeType = new UserType<DateTime>(0, 0, 0, null, new List<DateTime> { new DateTime(2010, 08, 17), new DateTime(2010, 05, 25) }, null, null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            //Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));

            //------------------------------------------------------------------------------
            //---- Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));
            //----
            //---- a propriedade enumeration não está a ser validada
            //----
            //---- Acrescentar em Validator<dateTime>
            //---- && (cType.Enumeration == null ? true : cType.Enumeration.Contains(value)) 
            //------------------------------------------------------------------------------

            //minInclusive
            _dateTimeType = new UserType<DateTime>(0, 0, 0, null, null, new NullableType<DateTime>(new DateTime(2010, 08, 17)), null, null, null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 16)));

            //minExclusive
            _dateTimeType = new UserType<DateTime>(0, 0, 0, null, null, null, new NullableType<DateTime>(new DateTime(2010, 08, 17)), null, null, null, null, null);
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 16)));

            //maxInclusive
            _dateTimeType = new UserType<DateTime>(0, 0, 0, null, null, null, null, new NullableType<DateTime>(new DateTime(2010, 08, 17)), null, null, null, null);
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 16)));
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));

            //maxExclusive
            _dateTimeType = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, new NullableType<DateTime>(new DateTime(2010, 08, 17)), null, null, null);
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 17)));
            Assert.IsTrue(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 16)));
            Assert.IsFalse(Validator.IsValid(_dateTimeType, new DateTime(2010, 08, 18)));
        }
    }
}
