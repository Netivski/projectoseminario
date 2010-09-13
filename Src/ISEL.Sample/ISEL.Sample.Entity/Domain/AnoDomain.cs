
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class AnoDomain : DomainObject<long>, IEntity
  
  {
    public AnoDomain () {}

    
    public virtual int Ano { get; set; }
  
    public virtual string Semestre { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.anoAno, Ano) && Validator.IsValid(UserTypeMetadata.semestreAno, Semestre) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Ano obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  