
using System;
using System.Collections.Generic;
using EDM.FoundationClasses.FoundationType;

namespace FutureView.ECom.Rtti.Base
{
    public class BaseUserTypeMetadata
    {
    
      protected BaseUserTypeMetadata() { }
      
      
        public static IUserType<long> RecordId = new UserType<long>(0, 0, 0, null, null, null, new NullableType<long>(0), new NullableType<long>(999999999), null, 0, null, null);
  
        public static IUserType<string> EmailAddress = new UserType<string>(256, 0, 0, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> EmailEnabled = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> PhonePrefix = new UserType<string>(5, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> PhoneNumber = new UserType<string>(9, 0, 0, @"[0-9]{9}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> FixedPhoneNumber = new UserType<string>(9, 0, 0, @"[0-9]{9}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> AddressCountry = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> AddressLine1 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> AddressLine2 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> AddressPostalCode = new UserType<string>(20, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> AddressPostalCodeDesc = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CustomerUserName = new UserType<string>(25, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CustomerPassword = new UserType<string>(50, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> CustomerAccountNonExpired = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> CustomerAccountNonLocked = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> CustomerCredentialsNonExpired = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> CustomerEnabled = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> CustomerLastFailedLogin = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> CustomerFailedLoginCount = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> CustomerLastLoginDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> CustomerCreateDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> CustomerBirthDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CustomerHint = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CustomerHintAnswer = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> LastPasswordPassword = new UserType<string>(50, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> LastPasswordCreateDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> SkuDescription = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> SkuAvailable = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> SkuPvp = new UserType<decimal>(0, 0, 0, null, null, null, new NullableType<decimal>(0), new NullableType<decimal>(1500), null, 0, null, null);
  
        public static IUserType<decimal> SkuDiscount = new UserType<decimal>(0, 0, 0, null, null, null, new NullableType<decimal>(0), new NullableType<decimal>(70), null, 0, null, null);
  
        public static IUserType<decimal> SkuFinalPrice = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> SkuIvaClass = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> SkuDateToMarket = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> SkuWeight = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> SkuEffectiveStartDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> SkuEffectiveEndDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> SkuMinOrderQty = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> SkuMaxOrderQty = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> SkuSmallImagePath = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> SkuLargeImagePath = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> SkuQty = new UserType<int>(0, 0, 0, null, null, null, new NullableType<int>(0), new NullableType<int>(9999), null, 0, null, null);
  
        public static IUserType<string> SkuSkuCode = new UserType<string>(25, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentName = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentAddressline1 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentAddressline2 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentCountry = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentPostalCode = new UserType<string>(20, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderShipmentPostalCodeDesc = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingName = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingAddressLine1 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingAddressLine2 = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingCountry = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingPostalCode = new UserType<string>(20, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingPostalCodeDesc = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderBillingNif = new UserType<string>(9, 0, 0, @"[0-9]{9}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderHeaderTotalAmount = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderHeaderTotalWeight = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> OrderHeaderTotalItens = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> OrderHeaderDateOfArrival = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderHeaderDiscountAmount = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderObs = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderHeaderStatusCode = new UserType<string>(10, 0, 0, null, new List<string> {"Created", "Submited", "Acepted", "Dispatched", "Canceled"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> OrderItemDescription = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<bool> OrderItemAvailable = new UserType<bool>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderItemPvp = new UserType<decimal>(0, 0, 0, null, null, null, new NullableType<decimal>(0), new NullableType<decimal>(1500), null, 0, null, null);
  
        public static IUserType<decimal> OrderItemDiscount = new UserType<decimal>(0, 0, 0, null, null, null, new NullableType<decimal>(0), new NullableType<decimal>(70), null, 0, null, null);
  
        public static IUserType<decimal> OrderItemFinalPrice = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderItemIvaClass = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> OrderItemDateToMarket = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> OrderItemWeight = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> OrderItemQty = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CategoryName = new UserType<string>(75, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CategoryDescription = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CategorySmallImagePath = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> CategoryLargeImagePath = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> CategoryEffectiveStartDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> CategoryEffectiveEndDate = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> RuntimeAuthorizationTypeName = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> RuntimeAuthorizationMethodName = new UserType<string>(256, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> RuntimeAuthorizationUserUserName = new UserType<string>(25, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> IndividualCustomerNif = new UserType<string>(9, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> IndividualCustomerFirstName = new UserType<string>(25, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> IndividualCustomerLastName = new UserType<string>(25, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> IndividualCustomerTitle = new UserType<string>(25, 0, 0, null, new List<string> {"Sr.", "Eng.", "Dr.", "Prof.", "Prof. Dr."}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> BusinessCustomerNif = new UserType<string>(9, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> BusinessCustomerName = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> BusinessCustomerCapital = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<decimal> BusinessCustomerCreditLimit = new UserType<decimal>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
    }
}
  