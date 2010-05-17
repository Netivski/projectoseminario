using System;

namespace EDM.FoundationClasses.FoundationType
{    
    public interface IBaseType
    {
        Type Type      { get; }
        int? MaxLength { get; }
        int? Precision { get; }
        int? Scale     { get; }   
    }
}
