using System;
using System.Collections.Generic;
using EDM.FoundationClasses.Exception.FoundationType;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator<T>
    {
        delegate bool UserTypeValidator(IUserType<T> cType, T value);

        static Dictionary<Type, UserTypeValidator> slaveMethod;


        static Validator()
        {
            slaveMethod = new Dictionary<Type, UserTypeValidator>();

            slaveMethod.Add(typeof(long)    , IsValidLong);
            slaveMethod.Add(typeof(int)     , IsValidInt);
            slaveMethod.Add(typeof(short)   , IsValidShort);
            slaveMethod.Add(typeof(byte)    , IsValidByte);
            slaveMethod.Add(typeof(decimal) , IsValidDecimal);
            slaveMethod.Add(typeof(float)   , IsValidFloat);
            slaveMethod.Add(typeof(double)  , IsValidDouble);
            slaveMethod.Add(typeof(string)  , IsValidString);
            slaveMethod.Add(typeof(DateTime), IsValidDateTime);
            slaveMethod.Add(typeof(bool)    , IsValidBool);
        }
       

        #region - Type Validator 

        static bool IsValidLong(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidInt(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidShort(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidByte(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidDecimal(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidFloat(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidDouble(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidString(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidDateTime(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        static bool IsValidBool(IUserType<T> cType, T value)
        {
            if (cType.BaseType != typeof(T)) return false;

            return false;
        }

        #endregion 

        ////Enum.IsDefined( 
        public static bool IsValid(IUserType<T> cType, T value)
        {
            if (cType == null) throw new ArgumentNullException("cType");            

            try
            {
                return slaveMethod[cType.BaseType](cType, value);
            }
            catch (KeyNotFoundException e)
            {
                throw new InvalidBaseTypeException(cType.BaseType, e);
            }
        }
    }
}
