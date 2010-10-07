
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
  public  class RuntimeAuthorizationUserDomain : DomainObject<long>, IEntity
  {
    public RuntimeAuthorizationUserDomain () {}

    
    public virtual string UserName { get; set; }
  public  virtual RuntimeAuthorization RuntimeAuthorization { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationUserUserName, UserName) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("RuntimeAuthorizationUser");
        
        if( !Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationUserUserName, UserName) )
        {
          ese.Add( new GeneralArgumentException<string>( "UserName", "RuntimeAuthorizationUserUserName", UserName) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(RuntimeAuthorizationUser obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  