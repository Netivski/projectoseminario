using System;
using System.Collections.Generic;
using EDM.FoundationClasses.Exception.FoundationType;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator
    {

        static bool IsBaseTypeValid(Type baseType, Type valueType)
        {
            return baseType == valueType;
        }

        public static bool IsValid(IUserType<long> cType, long value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(long) ) &&  false;
        }

        public static bool IsValid(IUserType<int> cType, int value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(int) ) && false;
        }

        public static bool IsValid(IUserType<short> cType, short value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(short) ) && false;
        }

        public static bool IsValid(IUserType<byte> cType, byte value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(byte) ) && false;
        }

        public static bool IsValid(IUserType<decimal> cType, decimal value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(decimal) ) && false;
        }

        public static bool IsValid(IUserType<float> cType, float value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(float) ) && false;
        }

        public static bool IsValid(IUserType<double> cType, double value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(double) ) && false;
        }

        public static bool IsValid(IUserType<string> cType, string value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(string) ) && false;
        }

        public static bool IsValid(IUserType<DateTime> cType, DateTime value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(DateTime) ) && false;
        }

        public static bool IsValid(IUserType<bool> cType, bool value)
        {
            return IsBaseTypeValid( cType.BaseType, typeof(bool) ) && false;
        }
    }
}
