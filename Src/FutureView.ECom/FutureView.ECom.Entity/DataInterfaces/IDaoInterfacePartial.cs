
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces.Base;

namespace FutureView.ECom.Entity.DataInterfaces
{
    // There's no need to declare each of the DAO interfaces in its own file, so just add them inline here.
    // But you're certainly welcome to put each declaration into its own file.
    #region Inline interface declarations
    
    public partial interface IContactDao : IContactDaoBase{ }
  
    public partial interface IEmailDao : IEmailDaoBase{ }
  
    public partial interface IPhoneDao : IPhoneDaoBase{ }
  
    public partial interface IFixedPhoneDao : IFixedPhoneDaoBase{ }
  
    public partial interface IFaxDao : IFaxDaoBase{ }
  
    public partial interface IMobileDao : IMobileDaoBase{ }
  
    public partial interface IAddressDao : IAddressDaoBase{ }
  
    public partial interface IBillingDao : IBillingDaoBase{ }
  
    public partial interface IShippingDao : IShippingDaoBase{ }
  
    public partial interface ICustomerAddressDao : ICustomerAddressDaoBase{ }
  
    public partial interface ICustomerDao : ICustomerDaoBase{ }
  
    public partial interface IIndividualCustomerDao : IIndividualCustomerDaoBase{ }
  
    public partial interface IBusinessCustomerDao : IBusinessCustomerDaoBase{ }
  
    public partial interface ILastPasswordDao : ILastPasswordDaoBase{ }
  
    public partial interface ISkuDao : ISkuDaoBase{ }
  
    public partial interface IOrderHeaderDao : IOrderHeaderDaoBase{ }
  
    public partial interface IOrderItemDao : IOrderItemDaoBase{ }
  
    public partial interface ICategoryDao : ICategoryDaoBase{ }
  
    public partial interface ICategorySkuDao : ICategorySkuDaoBase{ }
  
    public partial interface IRuntimeAuthorizationDao : IRuntimeAuthorizationDaoBase{ }
  
    public partial interface IRuntimeAuthorizationUserDao : IRuntimeAuthorizationUserDaoBase{ }
   
    #endregion
}
  