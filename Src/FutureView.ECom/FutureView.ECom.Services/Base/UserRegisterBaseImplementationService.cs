
using System;        
using EDM.FoundationClasses.Patterns;

namespace FutureView.ECom.Services.Base
{
    public class UserRegisterBaseImplementationService : UserRegisterBaseService
    {        
          
        #region - RegisterIndividualCustomer        
        protected override long RegisterIndividualCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "RegisterIndividualCustomerLogic" ));
        }
        #endregion
    
        #region - RegisterBusinessCustomer        
        protected override long RegisterBusinessCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "RegisterBusinessCustomerLogic" ));
        }
        #endregion
           
    }
}
  