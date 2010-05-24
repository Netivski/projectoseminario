using System;

namespace EDM.Generator.Exception
{
    internal class EDMFileNotFoundException: GeneralException
    {
        public EDMFileNotFoundException( string filePath ): base( string.Format( "Unable to locate the specified file. {0}", filePath ))
        {
        }

    }
}
