
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;

namespace FutureView.ECom.Entity.DataInterfaces.Base
{
    /// <summary>
    /// Provides an interface for retrieving DAO objects
    ///</summary>

    public interface IDaoFactoryBase
    {
      
    IContactDao GetContactDao();
  
    IEmailDao GetEmailDao();
  
    IPhoneDao GetPhoneDao();
  
    IFixedPhoneDao GetFixedPhoneDao();
  
    IFaxDao GetFaxDao();
  
    IMobileDao GetMobileDao();
  
    IAddressDao GetAddressDao();
  
    IBillingDao GetBillingDao();
  
    IShippingDao GetShippingDao();
  
    ICustomerAddressDao GetCustomerAddressDao();
  
    ICustomerDao GetCustomerDao();
  
    IIndividualCustomerDao GetIndividualCustomerDao();
  
    IBusinessCustomerDao GetBusinessCustomerDao();
  
    ILastPasswordDao GetLastPasswordDao();
  
    ISkuDao GetSkuDao();
  
    IOrderHeaderDao GetOrderHeaderDao();
  
    IOrderItemDao GetOrderItemDao();
  
    ICategoryDao GetCategoryDao();
  
    ICategorySkuDao GetCategorySkuDao();
  
    IRuntimeAuthorizationDao GetRuntimeAuthorizationDao();
  
    IRuntimeAuthorizationUserDao GetRuntimeAuthorizationUserDao();
  
    }
}
  