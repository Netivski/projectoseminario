using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.DataInterfaces.Base;

namespace FutureView.ECom.Entity.Data
{
    public partial class CustomerDao : AbstractNHibernateDao<Customer, long>, ICustomerDao 
    {
        public Customer GetByUserName(string UserName)
        {
            return GetUniqueByExample(new IndividualCustomer() { UserName = UserName }, "Password", "AccountNonExpired", "AccountNonLocked", "CredentialsNonExpired", "Enabled", "LastFailedLogin", "FailedLoginCount", "LastLoginDate", "CreateDate", "BirthDate", "Hint", "HintAnswer");
        }

        public Customer GetByUserNameAndPassword(string UserName, string Password)
        {
            return GetUniqueByExample(new IndividualCustomer() { UserName = UserName, Password = Password }, "AccountNonExpired", "AccountNonLocked", "CredentialsNonExpired", "Enabled", "LastFailedLogin", "FailedLoginCount", "LastLoginDate", "CreateDate", "BirthDate", "Hint", "HintAnswer");
        }

    }
}
  