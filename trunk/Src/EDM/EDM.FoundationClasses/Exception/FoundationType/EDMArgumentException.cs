using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class EDMArgumentException : ArgumentException
    {
        public EDMArgumentException(string message) :
            base(message){}
    }
}
