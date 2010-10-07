
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.DataInterfaces.Base;



namespace FutureView.ECom.Entity.Data
{
       
    public partial class ContactDao : AbstractNHibernateDao<Contact, long>, IContactDao { }
      
    public partial class EmailDao : AbstractNHibernateDao<Email, long>, IEmailDao { }
      
    public partial class PhoneDao : AbstractNHibernateDao<Phone, long>, IPhoneDao { }
      
    public partial class FixedPhoneDao : AbstractNHibernateDao<FixedPhone, long>, IFixedPhoneDao { }
      
    public partial class FaxDao : AbstractNHibernateDao<Fax, long>, IFaxDao { }
      
    public partial class MobileDao : AbstractNHibernateDao<Mobile, long>, IMobileDao { }
      
    public partial class AddressDao : AbstractNHibernateDao<Address, long>, IAddressDao { }
      
    public partial class BillingDao : AbstractNHibernateDao<Billing, long>, IBillingDao { }
      
    public partial class ShippingDao : AbstractNHibernateDao<Shipping, long>, IShippingDao { }
      
    public partial class CustomerAddressDao : AbstractNHibernateDao<CustomerAddress, long>, ICustomerAddressDao { }
      
    public partial class CustomerDao : AbstractNHibernateDao<Customer, long>, ICustomerDao { }
      
    public partial class IndividualCustomerDao : AbstractNHibernateDao<IndividualCustomer, long>, IIndividualCustomerDao { }
      
    public partial class BusinessCustomerDao : AbstractNHibernateDao<BusinessCustomer, long>, IBusinessCustomerDao { }
      
    public partial class LastPasswordDao : AbstractNHibernateDao<LastPassword, long>, ILastPasswordDao { }
      
    public partial class SkuDao : AbstractNHibernateDao<Sku, long>, ISkuDao { }
      
    public partial class OrderHeaderDao : AbstractNHibernateDao<OrderHeader, long>, IOrderHeaderDao { }
      
    public partial class OrderItemDao : AbstractNHibernateDao<OrderItem, long>, IOrderItemDao { }
      
    public partial class CategoryDao : AbstractNHibernateDao<Category, long>, ICategoryDao { }
      
    public partial class CategorySkuDao : AbstractNHibernateDao<CategorySku, long>, ICategorySkuDao { }
      
    public partial class RuntimeAuthorizationDao : AbstractNHibernateDao<RuntimeAuthorization, long>, IRuntimeAuthorizationDao { }
      
    public partial class RuntimeAuthorizationUserDao : AbstractNHibernateDao<RuntimeAuthorizationUser, long>, IRuntimeAuthorizationUserDao { }
  
}
  