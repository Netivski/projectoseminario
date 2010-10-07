
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;

namespace FutureView.ECom.Entity.Domain
{
  [Serializable]
  public  class LastPasswordDomain : DomainObject<long>, IEntity
  {
    public LastPasswordDomain () {}

    
    public virtual string Password { get; set; }
  
    public virtual DateTime CreateDate { get; set; }
  public  virtual Customer Customer { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.LastPasswordPassword, Password) && Validator.IsValid(UserTypeMetadata.LastPasswordCreateDate, CreateDate) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("LastPassword");
        
        if( !Validator.IsValid(UserTypeMetadata.LastPasswordPassword, Password) )
        {
          ese.Add( new GeneralArgumentException<string>( "Password", "LastPasswordPassword", Password) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.LastPasswordCreateDate, CreateDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "CreateDate", "LastPasswordCreateDate", CreateDate) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(LastPassword obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  