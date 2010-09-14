
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
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
  

    public virtual bool IsValid
    {
      get
      {
        return Validator.IsValid(UserTypeMetadata.nomeTurma, Nome) ;
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Turma");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeTurma, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeTurma", Nome) );
        }
  
    
        return ese;
      }
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
  