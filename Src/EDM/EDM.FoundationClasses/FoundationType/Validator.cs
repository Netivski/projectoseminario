﻿using System;
using System.Collections.Generic;
using EDM.FoundationClasses.Exception.FoundationType;
using System.Text.RegularExpressions;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator
    {

        /*
         * Alterei a interface IUserType para retornar NullableType<T> em vez de T
         * Parece-me melhor utilizar os Nullables do Runtime porque conseguem o mesmo resultado
         * Não fiz a alteração pois não se ficava por aqui, é preciso alterar os XSLT's também
         * */

        static int NumberOfFactionDigits(string value)
        {
            string[] sep;
            if (value.Contains(","))
                sep = value.Split(',');
            else if (value.Contains("."))
                sep = value.Split('.');
            else
                return 0;
            return sep[1].Length;
        }

        static bool IsWithinPattern(String pattern, String value) {
            return pattern == null ? true :
                Regex.Match(value.ToString(), pattern).Success;
        }
        
        static bool IsBaseTypeValid(Type baseType, Type valueType)
        {
            return baseType == valueType;
        }

        public static bool IsValid(IUserType<long> cType, long value)
        {
            return (value.ToString().Length <= cType.TotalDigits || cType.TotalDigits == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);

            //return IsBaseTypeValid( cType.BaseType, typeof(long) ) &&  false;
        }

        public static bool IsValid(IUserType<int> cType, int value)
        {
            return (value.ToString().Length <= cType.TotalDigits || cType.TotalDigits == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);

            //return IsBaseTypeValid( cType.BaseType, typeof(int) ) && false;
        }

        public static bool IsValid(IUserType<short> cType, short value)
        {
            return (value.ToString().Length <= cType.TotalDigits || cType.TotalDigits == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            //return IsBaseTypeValid( cType.BaseType, typeof(short) ) && false;
        }

        public static bool IsValid(IUserType<byte> cType, byte value)
        {
            return (value.ToString().Length <= cType.TotalDigits || cType.TotalDigits == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            //return IsBaseTypeValid( cType.BaseType, typeof(byte) ) && false;
        }

        public static bool IsValid(IUserType<decimal> cType, decimal value)
        {
            return (value.ToString().Length <= cType.TotalDigits || cType.TotalDigits == 0)
                && (NumberOfFactionDigits(value.ToString()) <= cType.FractionDigits || cType.FractionDigits == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            //return IsBaseTypeValid( cType.BaseType, typeof(decimal) ) && false;
        }

        public static bool IsValid(IUserType<float> cType, float value)
        {
            return IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            //return IsBaseTypeValid( cType.BaseType, typeof(float) ) && false;
        }

        public static bool IsValid(IUserType<double> cType, double value)
        {
            return IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            //return IsBaseTypeValid( cType.BaseType, typeof(double) ) && false;
        }

        public static bool IsValid(IUserType<string> cType, string value)
        {
            return (value.ToString().Length <= cType.Length || cType.Length == 0)
                && IsWithinPattern(cType.Pattern, value.ToString())
                && (value.Length <= cType.MaxLength || cType.MaxLength == 0)
                && value.Length >= cType.MinLength;

            //return IsBaseTypeValid(cType.BaseType, typeof(string)) && false;
        }

        public static bool IsValid(IUserType<DateTime> cType, DateTime value)
        {
            return IsWithinPattern(cType.Pattern, value.ToString())
                && (cType.MaxInclusive == null ? true : value <= cType.MaxInclusive.Value)
                && (cType.MaxExclusive == null ? true : value < cType.MaxExclusive.Value)
                && (cType.MinInclusive == null ? true : value >= cType.MinInclusive.Value)
                && (cType.MinExclusive == null ? true : value > cType.MinExclusive.Value);
            
            //return IsBaseTypeValid( cType.BaseType, typeof(DateTime) ) && false;
        }

        public static bool IsValid(IUserType<bool> cType, bool value)
        {
            return true;
        }
    }
}
