
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class DisciplinaDomain : DomainObject<long>, IEntity
  
  {
    public DisciplinaDomain () {}

    
    public virtual string Nome { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomeDisciplina, Nome) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Disciplina obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  