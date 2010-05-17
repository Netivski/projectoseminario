using System;

namespace EDM.FoundationClasses.FoundationType
{
    public struct Enumeration<T>
    {
        public Enumeration( T value, string description ) 
        {
            this.value       = value;
            this.description = description;
        }

        
        T      value;
        string description;

        
        public T      Value       { get{ return value; } }
        public string Description { get { return description; } }
    }
}
