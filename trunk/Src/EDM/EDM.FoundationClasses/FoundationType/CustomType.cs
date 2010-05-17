using System;
using System.Collections.Generic;

namespace EDM.FoundationClasses.FoundationType
{
    public class CustomType<T>: ICustomType<T>
    {
        public CustomType(IBaseType baseType, int length, int minLength, int maxLength, string pattern, List<Enumeration<T>> enumeration, T minInclusive, T minExclusive, T maxInclusive, T maxExclusive, WhiteSpaceEnum? whiteSpace, short? totalDigits, short? fractionDigits)
        {
            if (baseType == null)                                    throw new ArgumentNullException("baseType");
            if (length < 0)                                          throw new ArgumentException("Argument length can't be negative!");
            if (minLength < 0)                                       throw new ArgumentException("Argument minLength can't be negative!");
            if (maxLength < 0)                                       throw new ArgumentException("Argument maxLength can't be negative!");            
            if (totalDigits.HasValue && totalDigits.Value < 0)       throw new ArgumentException("Argument totalDigits can't be negative!");
            if (fractionDigits.HasValue && fractionDigits.Value < 0) throw new ArgumentException("Argument fractionDigits can't be negative!");

            this.baseType       = baseType;
            this.length         = length;
            this.minLength      = minLength;
            this.maxLength      = maxLength;
            this.pattern        = pattern;
            this.enumeration    = enumeration;
            this.maxInclusive   = maxInclusive;
            this.maxExclusive   = maxExclusive;
            this.minInclusive   = minInclusive;
            this.minExclusive   = minExclusive;
            this.whiteSpace     = whiteSpace;
            this.totalDigits    = totalDigits;
            this.fractionDigits = fractionDigits;
        }

        IBaseType            baseType;
        int                  length;
        int                  minLength;
        int                  maxLength;
        string               pattern;
        List<Enumeration<T>> enumeration;
        T                    maxInclusive;
        T                    maxExclusive;
        T                    minInclusive;
        T                    minExclusive;
        WhiteSpaceEnum?      whiteSpace;
        short?               totalDigits;
        short?               fractionDigits;

        public IBaseType BaseType { get { return baseType; } }

        public int Length { get { return length; } }

        public int MinLength {  get { return minLength; } }

        public int MaxLength { get { return maxLength; } }

        public string Pattern { get { return pattern; } }

        public List<Enumeration<T>> Enumeration { get{ return enumeration;} }

        public T MaxInclusive { get{ return maxInclusive; } }

        public T MaxExclusive { get{ return maxExclusive; } }

        public T MinInclusive { get{ return minInclusive; } }

        public T MinExclusive { get{ return minExclusive; } }

        public WhiteSpaceEnum? WhiteSpace {  get { return whiteSpace; }  }

        public short? TotalDigits {  get { return totalDigits; } }

        public short? FractionDigits { get { return fractionDigits; } }
    }
}
