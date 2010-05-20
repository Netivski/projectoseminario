using System;
using System.Collections.Generic;
using EDM.FoundationClasses.Exception.FoundationType;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator
    {

        #region - Type Validator 

        static bool IsValid(IUserType<long> cType, long value)
        {
            return false;
        }

        static bool IsValid(IUserType<int> cType, int value)
        {
            return false;
        }

        static bool IsValid(IUserType<short> cType, short value)
        {
            return false;
        }

        static bool IsValid(IUserType<byte> cType, byte value)
        {
            return false;
        }

        static bool IsValid(IUserType<decimal> cType, decimal value)
        {
            return false;
        }

        static bool IsValid(IUserType<float> cType, float value)
        {
            return false;
        }

        static bool IsValid(IUserType<double> cType, double value)
        {
            return false;
        }

        static bool IsValid(IUserType<string> cType, string value)
        {
            return false;
        }

        static bool IsValid(IUserType<DateTime> cType, DateTime value)
        {
            return false;
        }

        static bool IsValid(IUserType<bool> cType, bool value)
        {
            return false;
        }

        #endregion 
    }
}
