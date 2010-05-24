using System;

namespace EDM.Generator.Exception
{
    internal class InvalidTransformDirectoryException : GeneralException
    {
        public InvalidTransformDirectoryException(string baseDirectory) : base(string.Format("Invalid Transform Directory Exception. {0}", baseDirectory)) { }
    }
}
