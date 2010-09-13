using System;

namespace EDM.Generator.Exception
{
    internal class ThreeDNotFoundException: GeneralException
    {
        public ThreeDNotFoundException( string filePath ): base( string.Format( "Unable to locate the specified file. {0}", filePath ))
        {
        }

    }
}
