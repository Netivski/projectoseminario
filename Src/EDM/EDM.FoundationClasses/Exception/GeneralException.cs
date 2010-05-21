using System;

namespace EDM.FoundationClasses.Exception
{
    public abstract class GeneralException: System.Exception
    {
        public GeneralException(): base() { }

        public GeneralException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}
