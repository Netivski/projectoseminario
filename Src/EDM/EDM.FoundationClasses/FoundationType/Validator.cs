using System;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator
    {
        public static bool IsValid<T>(IUserType<T> cType, T value)
        {
            if (cType == null) throw new ArgumentNullException("cType");

            //Enum.IsDefined( 

            return false;
        }
    }
}
