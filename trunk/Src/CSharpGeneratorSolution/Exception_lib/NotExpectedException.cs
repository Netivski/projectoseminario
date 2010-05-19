using System;

namespace Exception_lib
{
    public class NotExpectedException : Exception
    {
        public NotExpectedException(String message) : base(message) { }

    }
}
