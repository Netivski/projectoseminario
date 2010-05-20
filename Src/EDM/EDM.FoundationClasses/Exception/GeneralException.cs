using System;

namespace EDM.FoundationClasses.Exception
{
    public class GeneralException: System.Exception
    {
        public GeneralException(): base() { }

        public GeneralException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}
