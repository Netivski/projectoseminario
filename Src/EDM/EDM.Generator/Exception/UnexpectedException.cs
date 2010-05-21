using System;

namespace EDM.Generator.Exception
{
    public class UnexpectedException : GeneralException
    {
        public UnexpectedException(System.Exception innerException) : base("Unexpected Exception.", innerException) { }

    }
}
