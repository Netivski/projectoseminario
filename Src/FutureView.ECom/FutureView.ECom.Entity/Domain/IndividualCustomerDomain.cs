
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
  public  class IndividualCustomerDomain : Customer
  {
    public IndividualCustomerDomain () {}

    
    public virtual string Nif { get; set; }
  
    public virtual string FirstName { get; set; }
  
    public virtual string LastName { get; set; }
  
    public virtual string Title { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.IndividualCustomerNif, Nif) && Validator.IsValid(UserTypeMetadata.IndividualCustomerFirstName, FirstName) && Validator.IsValid(UserTypeMetadata.IndividualCustomerLastName, LastName) && Validator.IsValid(UserTypeMetadata.IndividualCustomerTitle, Title) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("IndividualCustomer");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerNif, Nif) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nif", "IndividualCustomerNif", Nif) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerFirstName, FirstName) )
        {
          ese.Add( new GeneralArgumentException<string>( "FirstName", "IndividualCustomerFirstName", FirstName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerLastName, LastName) )
        {
          ese.Add( new GeneralArgumentException<string>( "LastName", "IndividualCustomerLastName", LastName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerTitle, Title) )
        {
          ese.Add( new GeneralArgumentException<string>( "Title", "IndividualCustomerTitle", Title) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(IndividualCustomer obj)
    {
       return base.Equals((Customer)obj);   
    }
  }
}
  