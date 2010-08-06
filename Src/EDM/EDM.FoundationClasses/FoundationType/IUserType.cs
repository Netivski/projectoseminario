using System;
using System.Collections.Generic;

namespace EDM.FoundationClasses.FoundationType
{
    //http://www.w3.org/TR/2001/REC-xmlschema-2-20010502/#rf-length
    public interface IUserType<T>
    {
        Type BaseType { get; }

        /// <summary>
        /// [Definition:]   length is the number of units of length, where units of length varies depending on the type that is being ·derived· from. The value of length ·must· be a nonNegativeInteger.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// [Definition:]   minLength is the minimum number of units of length, where units of length varies depending on the type that is being ·derived· from. The value of minLength  ·must· be a nonNegativeInteger.
        /// </summary>
        int MinLength { get; }

        /// <summary>
        /// [Definition:]   maxLength is the maximum number of units of length, where units of length varies depending on the type that is being ·derived· from. The value of maxLength  ·must· be a nonNegativeInteger.
        /// </summary>
        int MaxLength { get; }

        /// <summary>
        /// [Definition:]   pattern is a constraint on the ·value space· of a datatype which is achieved by constraining the ·lexical space· to literals which match a specific pattern. The value of pattern  ·must· be a ·regular expression·.
        /// </summary>        
        string Pattern { get; }

        /// <summary>
        /// [Definition:]   enumeration constrains the ·value space· to a specified set of values.
        /// </summary>       
        List<T> Enumeration { get; }

        /// <summary>
        /// [Definition:]   maxInclusive is the ·inclusive upper bound· of the ·value space· for a datatype with the ·ordered· property. The value of maxInclusive ·must· be in the ·value space· of the ·base type·. 
        /// </summary>
        NullableType<T> MaxInclusive { get; }

        /// <summary>
        /// [Definition:]   maxExclusive is the ·exclusive upper bound· of the ·value space· for a datatype with the ·ordered· property. The value of maxExclusive  ·must· be in the ·value space· of the ·base type· or be equal to {value} in {base type definition}. 
        /// </summary>
        NullableType<T> MaxExclusive { get; }

        /// <summary>
        /// [Definition:]   minInclusive is the ·inclusive lower bound· of the ·value space· for a datatype with the ·ordered· property. The value of minInclusive ·must· be in the ·value space· of the ·base type·. 
        /// </summary>
        NullableType<T> MinInclusive { get; }

        /// <summary>
        /// [Definition:]   minExclusive is the ·exclusive lower bound· of the ·value space· for a datatype with the ·ordered· property. The value of minExclusive  ·must· be in the ·value space· of the ·base type· or be equal to {value} in {base type definition}. 
        /// </summary>        
        NullableType<T> MinExclusive { get; }

        /// <summary>
        /// [Definition:]   whiteSpace constrains the ·value space· of types ·derived· from string such that the various behaviors specified in Attribute Value Normalization in [XML 1.0 (Second Edition)] are realized. The value of whiteSpace must be one of {preserve, replace, collapse}.
        /// </summary>
        WhiteSpaceEnum? WhiteSpace { get; }

        /// <summary>
        /// [Definition:]   totalDigits is the maximum number of digits in values of datatypes ·derived· from decimal. The value of totalDigits ·must· be a positiveInteger.
        /// </summary>
        short? TotalDigits { get; }

        /// <summary>
        /// [Definition:]   fractionDigits is the maximum number of digits in the fractional part of values of datatypes ·derived· from decimal. The value of fractionDigits  ·must· be a nonNegativeInteger .
        /// </summary>
        short? FractionDigits { get; }
    }
}
