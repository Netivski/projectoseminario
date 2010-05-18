using System;
using EDM.FoundationClasses.FoundationType;

namespace GenRtti
{
    public static class UserType
    {
        public static ICustomType<int> customInt = new CustomType<int>(PlatformType.UInt, 2, 2, 2, null, null, 10, 9, 11, 12, null, null, null);
        
        static void test()
        {
            Validator.IsValid(customInt, 123);
        }
    }
}
