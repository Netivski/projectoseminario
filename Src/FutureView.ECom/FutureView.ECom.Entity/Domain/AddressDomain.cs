
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
  public abstract class AddressDomain : Contact
  {
    public AddressDomain () {}

    
    public virtual string Country { get; set; }
  
    public virtual string Line1 { get; set; }
  
    public virtual string Line2 { get; set; }
  
    public virtual string PostalCode { get; set; }
  
    public virtual string PostalCodeDesc { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.AddressCountry, Country) && Validator.IsValid(UserTypeMetadata.AddressLine1, Line1) && Validator.IsValid(UserTypeMetadata.AddressLine2, Line2) && Validator.IsValid(UserTypeMetadata.AddressPostalCode, PostalCode) && Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, PostalCodeDesc) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Address");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.AddressCountry, Country) )
        {
          ese.Add( new GeneralArgumentException<string>( "Country", "AddressCountry", Country) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.AddressLine1, Line1) )
        {
          ese.Add( new GeneralArgumentException<string>( "Line1", "AddressLine1", Line1) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.AddressLine2, Line2) )
        {
          ese.Add( new GeneralArgumentException<string>( "Line2", "AddressLine2", Line2) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, PostalCode) )
        {
          ese.Add( new GeneralArgumentException<string>( "PostalCode", "AddressPostalCode", PostalCode) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, PostalCodeDesc) )
        {
          ese.Add( new GeneralArgumentException<string>( "PostalCodeDesc", "AddressPostalCodeDesc", PostalCodeDesc) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Address obj)
    {
       return base.Equals((Contact)obj);   
    }
  }
}
  