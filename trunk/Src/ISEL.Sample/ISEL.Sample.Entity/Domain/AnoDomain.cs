
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
  public  class AnoDomain : DomainObject<long>, IEntity
  {
    public AnoDomain () {}

    
    public virtual int Ano { get; set; }
  
    public virtual string Semestre { get; set; }
  

    public virtual bool IsValid
    {
      get
      {
        return Validator.IsValid(UserTypeMetadata.anoAno, Ano) && Validator.IsValid(UserTypeMetadata.semestreAno, Semestre) ;
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Ano");
        
        if( !Validator.IsValid(UserTypeMetadata.anoAno, Ano) )
        {
          ese.Add( new GeneralArgumentException<int>( "Ano", "anoAno", Ano) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.semestreAno, Semestre) )
        {
          ese.Add( new GeneralArgumentException<string>( "Semestre", "semestreAno", Semestre) );
        }
  
    
        return ese;
      }
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
  