using System;

namespace EDM.Generator.Exception
{
    internal class UnexpectedException : GeneralException
    {
        public UnexpectedException(System.Exception innerException) : base("Unexpected Exception.", innerException) { }

    }
}
