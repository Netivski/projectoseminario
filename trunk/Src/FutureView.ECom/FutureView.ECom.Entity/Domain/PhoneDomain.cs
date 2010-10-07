
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
  public  class PhoneDomain : Contact
  {
    public PhoneDomain () {}

    
    public virtual string Prefix { get; set; }
  
    public virtual string Number { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.PhonePrefix, Prefix) && Validator.IsValid(UserTypeMetadata.PhoneNumber, Number) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Phone");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, Prefix) )
        {
          ese.Add( new GeneralArgumentException<string>( "Prefix", "PhonePrefix", Prefix) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, Number) )
        {
          ese.Add( new GeneralArgumentException<string>( "Number", "PhoneNumber", Number) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Phone obj)
    {
       return base.Equals((Contact)obj);   
    }
  }
}
  