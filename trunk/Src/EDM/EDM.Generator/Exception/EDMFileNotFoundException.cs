using System;

namespace EDM.Generator.Exception
{
    internal class InvalidEDMStateException: GeneralException
    {
        public InvalidEDMStateException(  ): base( "Invalid EDM State. ")
        {
        }

    }
}
