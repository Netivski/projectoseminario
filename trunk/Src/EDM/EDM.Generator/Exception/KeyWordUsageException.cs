using System;

namespace EDM.Generator.Exception
{
    internal class KeyWordUsageException : GeneralException
    {
        public KeyWordUsageException(string message) : base(string.Format("CSharp Keywords cannot be used to name Types, Entities, Fields, Components, Business Processes or Business Process params. {0}", message)) { }
    }
}
