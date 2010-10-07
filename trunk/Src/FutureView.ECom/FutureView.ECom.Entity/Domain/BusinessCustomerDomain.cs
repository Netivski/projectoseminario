
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
  public  class BusinessCustomerDomain : Customer
  {
    public BusinessCustomerDomain () {}

    
    public virtual string Nif { get; set; }
  
    public virtual string Name { get; set; }
  
    public virtual decimal Capital { get; set; }
  
    public virtual decimal CreditLimit { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.BusinessCustomerNif, Nif) && Validator.IsValid(UserTypeMetadata.BusinessCustomerName, Name) && Validator.IsValid(UserTypeMetadata.BusinessCustomerCapital, Capital) && Validator.IsValid(UserTypeMetadata.BusinessCustomerCreditLimit, CreditLimit) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("BusinessCustomer");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerNif, Nif) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nif", "BusinessCustomerNif", Nif) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerName, Name) )
        {
          ese.Add( new GeneralArgumentException<string>( "Name", "BusinessCustomerName", Name) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerCapital, Capital) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Capital", "BusinessCustomerCapital", Capital) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerCreditLimit, CreditLimit) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "CreditLimit", "BusinessCustomerCreditLimit", CreditLimit) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(BusinessCustomer obj)
    {
       return base.Equals((Customer)obj);   
    }
  }
}
  