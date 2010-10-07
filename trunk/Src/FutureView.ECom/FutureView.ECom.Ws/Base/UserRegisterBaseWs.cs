
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using FutureView.ECom.Entity;
using FutureView.ECom.Services;

namespace FutureView.ECom.Ws.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class UserRegisterBaseWs : System.Web.Services.WebService
    {
            
        [WebMethod]
        public long RegisterIndividualCustomer(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {                              
          return Singleton<UserRegisterService>.Current.RegisterIndividualCustomer(UserName, Password, BirthDate, Hint, HintAnswer, Nif, FirstName, LastName, Title, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);
        }        
    
        [WebMethod]
        public long RegisterBusinessCustomer(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
        {                              
          return Singleton<UserRegisterService>.Current.RegisterBusinessCustomer(UserName, Password, BirthDate, Hint, HintAnswer, Nif, Name, Capital, EmailAddress, PhonePrefix, PhoneNumber, FixedPhonePrefix, FixedPhoneNumber, FaxPrefix, FaxNumber, MobilePrefix, MobileNumber, BillingCountry, BillingLine1, BillingLine2, BillingPostalCode, BillingPostalCodeDesc, ShippingCountry, ShippingLine1, ShippingLine2, ShippingPostalCode, ShippingPostalCodeDesc, CustomerAddressCountry, CustomerAddressLine1, CustomerAddressLine2, CustomerAddressPostalCode, CustomerAddressPostalCodeDesc);
        }        
                                 
    }
}
  