
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class DirectorSegundaLinhaDomain : Director
  {
    public DirectorSegundaLinhaDomain () {}

    
    public virtual int Antiguidade { get; set; }
  

    public override bool IsValid()
    {
      return  base.IsValid() && Validator.IsValid(UserTypeMetadata.antiguidadeDirectorSegundaLinha, Antiguidade) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(DirectorSegundaLinha obj)
    {
       return base.Equals((Director)obj);   
    }
  }
}
  