using System;

namespace EDM.FoundationClasses.Exception.FoundationType
{
    public class GeneralArgumentException<T> : ArgumentException
    {
        public GeneralArgumentException(string argumentName, string expectedType, T value) : base()
        {
            ArgumentName = argumentName;
            ExpectedType = expectedType;
            Value        = value;
        }

        public string ArgumentName { get; protected set; }
        public string ExpectedType { get; protected set; }
        public T      Value        { get; protected set; }

        public override string Message
        {
            get
            {
                return string.Format("Invalid argument {0} - Expected type: {1}, Value Found: {2}", ArgumentName, ExpectedType, Value);
            }
        }
    }
}
