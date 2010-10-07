using System;        
using EDM.FoundationClasses.Patterns;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.Data;
using FutureView.ECom.Entity.DataInterfaces;

namespace FutureView.ECom.Services
{
  public class UserRegisterService : Base.UserRegisterBaseImplementationService
  {
      protected override long RegisterIndividualCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string FirstName, string LastName, string Title, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
      {
          Customer customer = new IndividualCustomer() { AccountNonExpired = true, AccountNonLocked = true, BirthDate = BirthDate, CreateDate = DateTime.Now, CredentialsNonExpired = true, Enabled = true, FailedLoginCount = 0, FirstName = FirstName, Hint = Hint, HintAnswer = HintAnswer, LastFailedLogin = false, LastLoginDate = new DateTime(1970, 1, 1), LastName = LastName, Nif = Nif, Password = Password, Title = Title, UserName = UserName };

          if (!string.IsNullOrEmpty(EmailAddress))              customer.AddContact(new Email() { Address = EmailAddress, Enabled = true });

          if( !string.IsNullOrEmpty( PhoneNumber ) )            customer.AddContact( new Phone(){ Number = PhoneNumber, Prefix = PhonePrefix } );
          if( !string.IsNullOrEmpty( FixedPhoneNumber ) )       customer.AddContact( new Phone(){ Number = FixedPhoneNumber, Prefix = FixedPhonePrefix } );
          if( !string.IsNullOrEmpty( MobileNumber ) )           customer.AddContact( new Phone(){ Number = MobileNumber, Prefix = MobilePrefix } );

          if( !string.IsNullOrEmpty( BillingCountry ) )         customer.AddContact( new Billing( ) { Country = BillingCountry, Line1 = BillingLine1, Line2 = BillingLine2, PostalCode = BillingPostalCode, PostalCodeDesc = BillingPostalCodeDesc } );
          if( !string.IsNullOrEmpty( ShippingCountry ) )        customer.AddContact( new Shipping( ) { Country = ShippingCountry, Line1 = ShippingLine1, Line2 = ShippingLine2, PostalCode = ShippingPostalCode, PostalCodeDesc = ShippingPostalCodeDesc } );
          if( !string.IsNullOrEmpty( CustomerAddressCountry ) ) customer.AddContact( new CustomerAddress( ) { Country = CustomerAddressCountry, Line1 = CustomerAddressLine1, Line2 = CustomerAddressLine2, PostalCode = CustomerAddressPostalCode, PostalCodeDesc = CustomerAddressPostalCodeDesc } );

          return DaoFactory.Current.GetCustomerDao().Save(customer).ID;
      }

      protected override long RegisterBusinessCustomerLogic(string UserName, string Password, DateTime BirthDate, string Hint, string HintAnswer, string Nif, string Name, decimal Capital, string EmailAddress, string PhonePrefix, string PhoneNumber, string FixedPhonePrefix, string FixedPhoneNumber, string FaxPrefix, string FaxNumber, string MobilePrefix, string MobileNumber, string BillingCountry, string BillingLine1, string BillingLine2, string BillingPostalCode, string BillingPostalCodeDesc, string ShippingCountry, string ShippingLine1, string ShippingLine2, string ShippingPostalCode, string ShippingPostalCodeDesc, string CustomerAddressCountry, string CustomerAddressLine1, string CustomerAddressLine2, string CustomerAddressPostalCode, string CustomerAddressPostalCodeDesc)
      {
          Customer customer = new BusinessCustomer() { AccountNonExpired = true, AccountNonLocked = true, BirthDate = BirthDate, CreateDate = DateTime.Now, CredentialsNonExpired = true, Enabled = true, FailedLoginCount = 0, Hint = Hint, HintAnswer = HintAnswer, LastFailedLogin = false, LastLoginDate = new DateTime(1970, 1, 1), Capital = Capital, CreditLimit = 7500, Name = Name, Nif = Nif, Password = Password, UserName = UserName };

          if (!string.IsNullOrEmpty(EmailAddress))              customer.AddContact(new Email() { Address = EmailAddress, Enabled = true });

          if( !string.IsNullOrEmpty( PhoneNumber ) )            customer.AddContact( new Phone(){ Number = PhoneNumber, Prefix = PhonePrefix } );
          if( !string.IsNullOrEmpty( FixedPhoneNumber ) )       customer.AddContact( new Phone(){ Number = FixedPhoneNumber, Prefix = FixedPhonePrefix } );
          if( !string.IsNullOrEmpty( MobileNumber ) )           customer.AddContact( new Phone(){ Number = MobileNumber, Prefix = MobilePrefix } );

          if( !string.IsNullOrEmpty( BillingCountry ) )         customer.AddContact( new Billing( ) { Country = BillingCountry, Line1 = BillingLine1, Line2 = BillingLine2, PostalCode = BillingPostalCode, PostalCodeDesc = BillingPostalCodeDesc } );
          if( !string.IsNullOrEmpty( ShippingCountry ) )        customer.AddContact( new Shipping( ) { Country = ShippingCountry, Line1 = ShippingLine1, Line2 = ShippingLine2, PostalCode = ShippingPostalCode, PostalCodeDesc = ShippingPostalCodeDesc } );
          if( !string.IsNullOrEmpty( CustomerAddressCountry ) ) customer.AddContact( new CustomerAddress( ) { Country = CustomerAddressCountry, Line1 = CustomerAddressLine1, Line2 = CustomerAddressLine2, PostalCode = CustomerAddressPostalCode, PostalCodeDesc = CustomerAddressPostalCodeDesc } );

          return DaoFactory.Current.GetCustomerDao().Save(customer).ID;          
      }
  }
}
  