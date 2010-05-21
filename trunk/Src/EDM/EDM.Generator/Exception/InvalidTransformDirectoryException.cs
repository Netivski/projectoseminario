using System;

namespace EDM.Generator.Exception
{
    public class InvalidTransformDirectoryException: GeneralException
    {
        public InvalidTransformDirectoryException(string baseDirectory) : base(string.Format("Invalid Transform Directory Exception. {0}", baseDirectory)) { }
    }
}
