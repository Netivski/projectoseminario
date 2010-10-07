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
            return null;
        }

        Customer GetByUserNameAndPassword(string UserName, string Password)
        {
            return null;
        }

    }
}
  