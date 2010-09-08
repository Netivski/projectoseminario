using System;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class InvalidBaseTypeException : GeneralException
    {
        public InvalidBaseTypeException( Type baseType, System.Exception innerException ) : base( string.Format( "Invalid Base Type {0}.", baseType.ToString() ), innerException )
        {
            BaseType = baseType;
        }

        public Type BaseType { get; protected set; }
    }
}
