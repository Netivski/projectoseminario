using System;
using EDM.FoundationClasses.Exception;

namespace EDM.FoundationClasses.Entity
{
    public interface IEntity
    {
        bool IsValid { get; }
        EntityStateException StateException { get; }
    }
}
