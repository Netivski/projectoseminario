
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
  public  class RuntimeAuthorizationDomain : DomainObject<long>, IEntity
  {
    public RuntimeAuthorizationDomain () {}

    
    IList<RuntimeAuthorizationUser> _Users = new List<RuntimeAuthorizationUser>();  
  
    public virtual string TypeName { get; set; }
  
    public virtual string MethodName { get; set; }
  
    public virtual IList<RuntimeAuthorizationUser> Users {
        get { return new List<RuntimeAuthorizationUser>(_Users).AsReadOnly(); }
        protected set { _Users = value; }
    }     
  
    public void AddRuntimeAuthorizationUser(RuntimeAuthorizationUser obj) {
        obj.RuntimeAuthorization = (RuntimeAuthorization)this;
        if (obj != null &&  !_Users.Contains(obj)) {
            _Users.Add(obj);
        }
    }

    public void RemoveRuntimeAuthorizationUser(RuntimeAuthorizationUser obj) {
        if (obj != null &&  _Users.Contains(obj)) {
            _Users.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationTypeName, TypeName) && Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationMethodName, MethodName) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("RuntimeAuthorization");
        
        if( !Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationTypeName, TypeName) )
        {
          ese.Add( new GeneralArgumentException<string>( "TypeName", "RuntimeAuthorizationTypeName", TypeName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.RuntimeAuthorizationMethodName, MethodName) )
        {
          ese.Add( new GeneralArgumentException<string>( "MethodName", "RuntimeAuthorizationMethodName", MethodName) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(RuntimeAuthorization obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  