
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
  public  class EmailDomain : Contact
  {
    public EmailDomain () {}

    
    public virtual string Address { get; set; }
  
    public virtual bool Enabled { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.EmailAddress, Address) && Validator.IsValid(UserTypeMetadata.EmailEnabled, Enabled) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Email");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.EmailAddress, Address) )
        {
          ese.Add( new GeneralArgumentException<string>( "Address", "EmailAddress", Address) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.EmailEnabled, Enabled) )
        {
          ese.Add( new GeneralArgumentException<bool>( "Enabled", "EmailEnabled", Enabled) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Email obj)
    {
       return base.Equals((Contact)obj);   
    }
  }
}
  