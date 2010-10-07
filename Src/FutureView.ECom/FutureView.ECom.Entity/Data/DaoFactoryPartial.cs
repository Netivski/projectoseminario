
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.DataInterfaces.Base;



namespace FutureView.ECom.Entity.Data
{
    /// <summary>
    /// Exposes access to NHibernate DAO classes.  Motivation for this DAO
    /// framework can be found at http://www.hibernate.org/328.html.
    /// </summary>
    public partial class DaoFactory : IDaoFactory
    {
      static readonly DaoFactory current = null;

      protected DaoFactory() { }

      static DaoFactory()
      {
        current = new DaoFactory();
      }

      public static DaoFactory Current
      {
        get { return current; }
      }


    
    public IContactDao GetContactDao() {
      return new ContactDao();
    }
  
    public IEmailDao GetEmailDao() {
      return new EmailDao();
    }
  
    public IPhoneDao GetPhoneDao() {
      return new PhoneDao();
    }
  
    public IFixedPhoneDao GetFixedPhoneDao() {
      return new FixedPhoneDao();
    }
  
    public IFaxDao GetFaxDao() {
      return new FaxDao();
    }
  
    public IMobileDao GetMobileDao() {
      return new MobileDao();
    }
  
    public IAddressDao GetAddressDao() {
      return new AddressDao();
    }
  
    public IBillingDao GetBillingDao() {
      return new BillingDao();
    }
  
    public IShippingDao GetShippingDao() {
      return new ShippingDao();
    }
  
    public ICustomerAddressDao GetCustomerAddressDao() {
      return new CustomerAddressDao();
    }
  
    public ICustomerDao GetCustomerDao() {
      return new CustomerDao();
    }
  
    public IIndividualCustomerDao GetIndividualCustomerDao() {
      return new IndividualCustomerDao();
    }
  
    public IBusinessCustomerDao GetBusinessCustomerDao() {
      return new BusinessCustomerDao();
    }
  
    public ILastPasswordDao GetLastPasswordDao() {
      return new LastPasswordDao();
    }
  
    public ISkuDao GetSkuDao() {
      return new SkuDao();
    }
  
    public IOrderHeaderDao GetOrderHeaderDao() {
      return new OrderHeaderDao();
    }
  
    public IOrderItemDao GetOrderItemDao() {
      return new OrderItemDao();
    }
  
    public ICategoryDao GetCategoryDao() {
      return new CategoryDao();
    }
  
    public ICategorySkuDao GetCategorySkuDao() {
      return new CategorySkuDao();
    }
  
    public IRuntimeAuthorizationDao GetRuntimeAuthorizationDao() {
      return new RuntimeAuthorizationDao();
    }
  
    public IRuntimeAuthorizationUserDao GetRuntimeAuthorizationUserDao() {
      return new RuntimeAuthorizationUserDao();
    }
  

    }
}
  