using System;
using System.Collections.Generic;

namespace EDM.FoundationClasses.FoundationType
{
    public class UserType<T>: IUserType<T>
    {
        public UserType(int length, int minLength, int maxLength, string pattern, List<T> enumeration, NullableType<T> minInclusive, NullableType<T> minExclusive, NullableType<T> maxInclusive, NullableType<T> maxExclusive, WhiteSpaceEnum? whiteSpace, short? totalDigits, short? fractionDigits)
        {
            if (length < 0)                                          throw new ArgumentException("Argument length can't be negative!");
            if (minLength < 0)                                       throw new ArgumentException("Argument minLength can't be negative!");
            if (maxLength < 0)                                       throw new ArgumentException("Argument maxLength can't be negative!");            
            if (totalDigits.HasValue && totalDigits.Value < 0)       throw new ArgumentException("Argument totalDigits can't be negative!");
            if (fractionDigits.HasValue && fractionDigits.Value < 0) throw new ArgumentException("Argument fractionDigits can't be negative!");

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

        int             length;
        int             minLength;
        int             maxLength;
        string          pattern;
        List<T>         enumeration;
        NullableType<T> maxInclusive;
        NullableType<T> maxExclusive;
        NullableType<T> minInclusive;
        NullableType<T> minExclusive;
        WhiteSpaceEnum? whiteSpace;
        short?          totalDigits;
        short?          fractionDigits;

        public Type BaseType { get { return typeof( T ); } }

        public int Length { get { return length; } }

        public int MinLength {  get { return minLength; } }

        public int MaxLength { get { return maxLength; } }

        public string Pattern { get { return pattern; } }

        public List<T> Enumeration { get{ return enumeration;} }

        public T MaxInclusive { get { return maxInclusive == null ? default(T) : maxInclusive.Value; } }

        public T MaxExclusive { get { return maxExclusive == null ? default(T) : maxExclusive.Value; } }

        public T MinInclusive { get { return minInclusive == null ? default(T) : minInclusive.Value; } }

        public T MinExclusive { get { return minExclusive == null ? default(T) : minExclusive.Value; } }

        public WhiteSpaceEnum? WhiteSpace {  get { return whiteSpace; }  }

        public short? TotalDigits {  get { return totalDigits; } }

        public short? FractionDigits { get { return fractionDigits; } }
    }
}
