using System;

namespace EDM.FoundationClasses.FoundationType
{    
    public interface IPlatformType
    {
        Type Type      { get; }
        int? MaxLength { get; }
        int? Precision { get; }
        int? Scale     { get; }   
    }
}
