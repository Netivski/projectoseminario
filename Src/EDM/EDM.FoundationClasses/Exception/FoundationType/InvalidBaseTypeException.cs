using System;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class InvalidBaseTypeException : GeneralException
    {
        public InvalidBaseTypeException( Type baseType, System.Exception innerException ) : base( string.Format( "Invalid Base Type {0}.", baseType.ToString() ), innerException )
        {
            this.baseType = baseType;
        }

        Type baseType = null;
        public Type BaseType { get { return baseType; } }
    }
}
