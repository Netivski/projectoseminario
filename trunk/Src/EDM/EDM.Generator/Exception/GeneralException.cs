using System;

namespace EDM.Generator.Exception
{
    internal abstract class GeneralException: System.Exception 
    {
        public GeneralException(): base() {}
        public GeneralException(string message): base(message){}
        public GeneralException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}
