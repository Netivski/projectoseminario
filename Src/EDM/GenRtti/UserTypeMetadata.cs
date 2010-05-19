using System;
using EDM.FoundationClasses.FoundationType;

namespace GenRtti
{
    public static class UserTypeMetadata
    {

        //Gerador - Objectos a gerar
        // 1 - Gerar todos os user types
        // 2 - Gerar a lista de enumeration do tipo

        public static IUserType<int> uInt = new UserType<int>(2, 2, 2, null, null, 10, 9, 11, 12, null, null, null);
        
        static void test()
        {
            Validator.IsValid(uInt, 123);
        }
    }
}
