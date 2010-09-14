using System;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class PreConditionException<T> : GeneralArgumentException<T>
    {
        public PreConditionException(string methodName, string argumentName, string expectedType, T value) : base(argumentName, expectedType, value) 
        {
            MethodName = methodName;
        }

        public string MethodName { get; protected set; }

        public override string Message
        {
            get
            {
                return string.Format("An error ocurred while validating PreConditions in {0}. {1}", MethodName, base.Message);
            }
        }
    }
}
