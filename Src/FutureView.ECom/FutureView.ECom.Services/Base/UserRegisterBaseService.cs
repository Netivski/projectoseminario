
using System;
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;


namespace FutureView.ECom.Services.Base
{
    public abstract class UserRegisterBaseService
    {        
            
        #region - RegisterIndividualCustomer
        protected virtual void RegisterIndividualCustomerValidatePreCondition(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "UserName", "CustomerUserName", UserName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, Password) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "Password", "CustomerPassword", Password);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerBirthDate, BirthDate) )
          {
            throw new PreConditionException<DateTime>("RegisterIndividualCustomer", "BirthDate", "CustomerBirthDate", BirthDate);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerHint, Hint) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "Hint", "CustomerHint", Hint);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerHintAnswer, HintAnswer) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "HintAnswer", "CustomerHintAnswer", HintAnswer);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerNif, Nif) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "Nif", "IndividualCustomerNif", Nif);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerFirstName, FirstName) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "FirstName", "IndividualCustomerFirstName", FirstName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerLastName, LastName) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "LastName", "IndividualCustomerLastName", LastName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.IndividualCustomerTitle, Title) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "Title", "IndividualCustomerTitle", Title);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.EmailAddress, EmailAddress) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "EmailAddress", "EmailAddress", EmailAddress);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, PhonePrefix) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "PhonePrefix", "PhonePrefix", PhonePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, PhoneNumber) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "PhoneNumber", "PhoneNumber", PhoneNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, FixedPhonePrefix) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "FixedPhonePrefix", "PhonePrefix", FixedPhonePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, FixedPhoneNumber) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "FixedPhoneNumber", "PhoneNumber", FixedPhoneNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, FaxPrefix) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "FaxPrefix", "PhonePrefix", FaxPrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, FaxNumber) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "FaxNumber", "PhoneNumber", FaxNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, MobilePrefix) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "MobilePrefix", "PhonePrefix", MobilePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, MobileNumber) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "MobileNumber", "PhoneNumber", MobileNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, BillingCountry) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "BillingCountry", "AddressCountry", BillingCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, BillingLine1) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "BillingLine1", "AddressLine1", BillingLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, BillingLine2) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "BillingLine2", "AddressLine2", BillingLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, BillingPostalCode) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "BillingPostalCode", "AddressPostalCode", BillingPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, BillingPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "BillingPostalCodeDesc", "AddressPostalCodeDesc", BillingPostalCodeDesc);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, ShippingCountry) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "ShippingCountry", "AddressCountry", ShippingCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, ShippingLine1) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "ShippingLine1", "AddressLine1", ShippingLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, ShippingLine2) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "ShippingLine2", "AddressLine2", ShippingLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, ShippingPostalCode) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "ShippingPostalCode", "AddressPostalCode", ShippingPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, ShippingPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "ShippingPostalCodeDesc", "AddressPostalCodeDesc", ShippingPostalCodeDesc);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, CustomerAddressCountry) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "CustomerAddressCountry", "AddressCountry", CustomerAddressCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, CustomerAddressLine1) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "CustomerAddressLine1", "AddressLine1", CustomerAddressLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, CustomerAddressLine2) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "CustomerAddressLine2", "AddressLine2", CustomerAddressLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, CustomerAddressPostalCode) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "CustomerAddressPostalCode", "AddressPostalCode", CustomerAddressPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, CustomerAddressPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterIndividualCustomer", "CustomerAddressPostalCodeDesc", "AddressPostalCodeDesc", CustomerAddressPostalCodeDesc);
          }
  
        }
        
        protected abstract long  RegisterIndividualCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc);  
        
        
        protected virtual void RegisterIndividualCustomerValidatePosCondition(long result)
        {
          if( !Validator.IsValid(UserTypeMetadata.RecordId, result) )
          {          
            throw new PosConditionException<long>("RegisterIndividualCustomer", "RecordId", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RegisterIndividualCustomerBaseService", MethodName="RegisterIndividualCustomer", Unrestricted = false)] 
        public virtual long RegisterIndividualCustomer(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          RegisterIndividualCustomerValidatePreCondition(UserName, Password, BirthDate, Hint, HintAnswer, Nif, FirstName, LastName, Title, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);
          long result = RegisterIndividualCustomerLogic(UserName, Password, BirthDate, Hint, HintAnswer, Nif, FirstName, LastName, Title, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);          
          RegisterIndividualCustomerValidatePosCondition(result);
          return result;
                      
        }
        #endregion
    
        #region - RegisterBusinessCustomer
        protected virtual void RegisterBusinessCustomerValidatePreCondition(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "UserName", "CustomerUserName", UserName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, Password) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "Password", "CustomerPassword", Password);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerBirthDate, BirthDate) )
          {
            throw new PreConditionException<DateTime>("RegisterBusinessCustomer", "BirthDate", "CustomerBirthDate", BirthDate);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerHint, Hint) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "Hint", "CustomerHint", Hint);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerHintAnswer, HintAnswer) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "HintAnswer", "CustomerHintAnswer", HintAnswer);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerNif, Nif) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "Nif", "BusinessCustomerNif", Nif);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerName, Name) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "Name", "BusinessCustomerName", Name);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.BusinessCustomerCapital, Capital) )
          {
            throw new PreConditionException<decimal>("RegisterBusinessCustomer", "Capital", "BusinessCustomerCapital", Capital);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.EmailAddress, EmailAddress) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "EmailAddress", "EmailAddress", EmailAddress);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, PhonePrefix) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "PhonePrefix", "PhonePrefix", PhonePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, PhoneNumber) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "PhoneNumber", "PhoneNumber", PhoneNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, FixedPhonePrefix) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "FixedPhonePrefix", "PhonePrefix", FixedPhonePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, FixedPhoneNumber) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "FixedPhoneNumber", "PhoneNumber", FixedPhoneNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, FaxPrefix) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "FaxPrefix", "PhonePrefix", FaxPrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, FaxNumber) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "FaxNumber", "PhoneNumber", FaxNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhonePrefix, MobilePrefix) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "MobilePrefix", "PhonePrefix", MobilePrefix);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.PhoneNumber, MobileNumber) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "MobileNumber", "PhoneNumber", MobileNumber);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, BillingCountry) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "BillingCountry", "AddressCountry", BillingCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, BillingLine1) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "BillingLine1", "AddressLine1", BillingLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, BillingLine2) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "BillingLine2", "AddressLine2", BillingLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, BillingPostalCode) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "BillingPostalCode", "AddressPostalCode", BillingPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, BillingPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "BillingPostalCodeDesc", "AddressPostalCodeDesc", BillingPostalCodeDesc);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, ShippingCountry) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "ShippingCountry", "AddressCountry", ShippingCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, ShippingLine1) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "ShippingLine1", "AddressLine1", ShippingLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, ShippingLine2) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "ShippingLine2", "AddressLine2", ShippingLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, ShippingPostalCode) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "ShippingPostalCode", "AddressPostalCode", ShippingPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, ShippingPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "ShippingPostalCodeDesc", "AddressPostalCodeDesc", ShippingPostalCodeDesc);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressCountry, CustomerAddressCountry) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "CustomerAddressCountry", "AddressCountry", CustomerAddressCountry);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine1, CustomerAddressLine1) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "CustomerAddressLine1", "AddressLine1", CustomerAddressLine1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressLine2, CustomerAddressLine2) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "CustomerAddressLine2", "AddressLine2", CustomerAddressLine2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCode, CustomerAddressPostalCode) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "CustomerAddressPostalCode", "AddressPostalCode", CustomerAddressPostalCode);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.AddressPostalCodeDesc, CustomerAddressPostalCodeDesc) )
          {
            throw new PreConditionException<string>("RegisterBusinessCustomer", "CustomerAddressPostalCodeDesc", "AddressPostalCodeDesc", CustomerAddressPostalCodeDesc);
          }
  
        }
        
        protected abstract long  RegisterBusinessCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc);  
        
        
        protected virtual void RegisterBusinessCustomerValidatePosCondition(long result)
        {
          if( !Validator.IsValid(UserTypeMetadata.RecordId, result) )
          {          
            throw new PosConditionException<long>("RegisterBusinessCustomer", "RecordId", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RegisterBusinessCustomerBaseService", MethodName="RegisterBusinessCustomer", Unrestricted = false)] 
        public virtual long RegisterBusinessCustomer(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          RegisterBusinessCustomerValidatePreCondition(UserName, Password, BirthDate, Hint, HintAnswer, Nif, Name, Capital, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);
          long result = RegisterBusinessCustomerLogic(UserName, Password, BirthDate, Hint, HintAnswer, Nif, Name, Capital, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);          
          RegisterBusinessCustomerValidatePosCondition(result);
          return result;
                      
        }
        #endregion
           
    }
}
  