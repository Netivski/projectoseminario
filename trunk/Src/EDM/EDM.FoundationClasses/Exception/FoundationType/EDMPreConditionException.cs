using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class EDMPreConditionException : EDMArgumentException
    {
        public EDMPreConditionException(string methodName, string expectedType, string value) :
            base(string.Concat("An error ocurred while validating PreConditions in ", methodName, ".  Invalid argument - Expected type: ", expectedType, ", Value Found: ", value)) { }
    }
}
