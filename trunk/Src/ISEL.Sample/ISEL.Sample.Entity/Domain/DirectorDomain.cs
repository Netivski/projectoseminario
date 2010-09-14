
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class DirectorDomain : Empregado
  {
    public DirectorDomain () {}

    
    public virtual double LimiteCartaoCredito { get; set; }
  

    public override bool IsValid()
    {
      return  base.IsValid() && Validator.IsValid(UserTypeMetadata.limiteCartaoCreditoDirector, LimiteCartaoCredito) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Director obj)
    {
       return base.Equals((Empregado)obj);   
    }
  }
}
  