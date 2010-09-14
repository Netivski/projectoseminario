using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class EDMPosConditionException : System.Exception
    {
        public EDMPosConditionException(string methodName, string expectedType, string value) :
            base(string.Concat("An error ocurred while validating Pos Conditions in ", methodName, ".  Invalid return type - Expected type: ", expectedType, ", Value Found: ", value)) { }
    }
}
