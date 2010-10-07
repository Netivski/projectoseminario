
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;

namespace FutureView.ECom.Entity.DataInterfaces.Base
{
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations 
      
    public interface IContactDaoBase : IDao<Contact, long>{ }
  
    public interface IEmailDaoBase : IDao<Email, long>{ }
  
    public interface IPhoneDaoBase : IDao<Phone, long>{ }
  
    public interface IFixedPhoneDaoBase : IDao<FixedPhone, long>{ }
  
    public interface IFaxDaoBase : IDao<Fax, long>{ }
  
    public interface IMobileDaoBase : IDao<Mobile, long>{ }
  
    public interface IAddressDaoBase : IDao<Address, long>{ }
  
    public interface IBillingDaoBase : IDao<Billing, long>{ }
  
    public interface IShippingDaoBase : IDao<Shipping, long>{ }
  
    public interface ICustomerAddressDaoBase : IDao<CustomerAddress, long>{ }
  
    public interface ICustomerDaoBase : IDao<Customer, long>{ }
  
    public interface IIndividualCustomerDaoBase : IDao<IndividualCustomer, long>{ }
  
    public interface IBusinessCustomerDaoBase : IDao<BusinessCustomer, long>{ }
  
    public interface ILastPasswordDaoBase : IDao<LastPassword, long>{ }
  
    public interface ISkuDaoBase : IDao<Sku, long>{ }
  
    public interface IOrderHeaderDaoBase : IDao<OrderHeader, long>{ }
  
    public interface IOrderItemDaoBase : IDao<OrderItem, long>{ }
  
    public interface ICategoryDaoBase : IDao<Category, long>{ }
  
    public interface ICategorySkuDaoBase : IDao<CategorySku, long>{ }
  
    public interface IRuntimeAuthorizationDaoBase : IDao<RuntimeAuthorization, long>{ }
  
    public interface IRuntimeAuthorizationUserDaoBase : IDao<RuntimeAuthorizationUser, long>{ }
  
    #endregion 
}
  