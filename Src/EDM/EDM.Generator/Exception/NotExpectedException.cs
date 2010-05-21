using System;

namespace EDM.Generator.Exception
{
    public class NotExpectedException : GeneralException
    {
        public NotExpectedException(String message) : base(message) { }

    }
}
