
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class TurmaDomain : DomainObject<long>, IEntity
  
  {
    public TurmaDomain () {}

    
    public virtual string Nome { get; set; }
  
    public virtual Curso Curso { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomeTurma, Nome) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Turma obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  