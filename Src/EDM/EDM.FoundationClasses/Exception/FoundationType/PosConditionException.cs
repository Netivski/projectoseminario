using System;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class PosConditionException<T> : GeneralException
    {
        public PosConditionException(string methodName, string expectedType, T value) : base() 
        {
            MethodName   = methodName;
            ExpectedType = expectedType;
            Value        = value;
        }

        public string MethodName   { get; protected set; }
        public string ExpectedType { get; protected set; }
        public T      Value        { get; protected set; }

        public override string Message
        {
            get
            {
                return string.Format("An error ocurred while validating Pos Conditions in {0}. Invalid return type - Expected type: {1}, Value Found: {2}", MethodName, ExpectedType, Value);
            }
        }
    }
}
