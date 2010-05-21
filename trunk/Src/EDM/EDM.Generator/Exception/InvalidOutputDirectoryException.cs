using System;

namespace EDM.Generator.Exception
{
    public class InvalidOutputDirectoryException: GeneralException
    {
        public InvalidOutputDirectoryException(string baseDirectory) : base(string.Format("Invalid Output Directory. {0}", baseDirectory)) { }
    }
}
