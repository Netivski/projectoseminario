
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Persistence.Data;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces.Base;

namespace FutureView.ECom.Entity.DataInterfaces
{
    public partial interface ICustomerDao : ICustomerDaoBase 
    {
        Customer GetByUserName(string UserName);
    }
}
  