using System;

namespace EDM.Generator.Exception
{
    public class EDMFileNotFoundException: GeneralException
    {
        public EDMFileNotFoundException( string filePath ): base( string.Format( "Unable to locate the specified file. {0}", filePath ))
        {
        }

    }
}
