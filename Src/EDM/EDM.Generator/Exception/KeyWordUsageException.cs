using System;

namespace EDM.Generator.Exception
{
    internal class KeyWordUsageException : GeneralException
    {
        public KeyWordUsageException(string message) : base(string.Format("CSharp Keywords cannot be used to name Entities, types or fields. {0}", message)) { }
    }
}
