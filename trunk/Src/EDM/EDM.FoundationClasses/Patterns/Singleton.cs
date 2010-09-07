using System;

namespace EDM.FoundationClasses.Patterns
{
    public class Singleton<T> where T : class, new()
    {
        static readonly T instance = null;

        static Singleton()
        {
            instance = new T();
        }

        public static T Current
        {
            get
            {
                return instance;
            }
        }
    }
}
