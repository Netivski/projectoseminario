
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
  public  class PersonDomain : DomainObject<long>, IEntity
  {
    public PersonDomain () {}

    
    public virtual string Nome { get; set; }
  

    public virtual bool IsValid
    {
      get
      {
        return Validator.IsValid(UserTypeMetadata.nomePerson, Nome) ;
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Person");
        
        if( !Validator.IsValid(UserTypeMetadata.nomePerson, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomePerson", Nome) );
        }
  
    
        return ese;
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Person obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  