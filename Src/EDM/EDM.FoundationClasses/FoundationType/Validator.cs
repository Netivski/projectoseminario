using System;

namespace EDM.FoundationClasses.FoundationType
{
    public static class Validator
    {
        public static bool IsValid<T>(ICustomType<T> cType, T value)
        {
            if (cType == null)                    throw new ArgumentNullException("cType");
            if (cType.BaseType.Type != typeof(T)) throw new ArgumentException("Invalid Argument Reference Type");  


            return false;
        }
    }
}
