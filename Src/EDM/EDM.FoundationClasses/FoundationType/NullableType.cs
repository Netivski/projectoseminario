using System;

namespace EDM.FoundationClasses.FoundationType
{
    public class NullableType<T>  
    {
        T value;

        public NullableType(T value)
        {
            this.value = value;
        }

        public T Value { get { return value; } }
    }
}
