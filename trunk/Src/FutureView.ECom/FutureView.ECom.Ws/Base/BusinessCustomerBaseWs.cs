
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using FutureView.ECom.Entity;
using FutureView.ECom.Services;

namespace FutureView.ECom.Ws.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class BusinessCustomerBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Nif, string Name, decimal Capital, decimal CreditLimit, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {        
            return Singleton<BusinessCustomerService>.Current.Create(Nif, Name, Capital, CreditLimit, UserName, Password, AccountNonExpired, AccountNonLocked, CredentialsNonExpired, Enabled, LastFailedLogin, FailedLoginCount, LastLoginDate, CreateDate, BirthDate, Hint, HintAnswer);
        }

        [WebMethod]
        public void Update(long recordId, string Nif, string Name, decimal Capital, decimal CreditLimit, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {
            Singleton<BusinessCustomerService>.Current.Update(recordId, Nif, Name, Capital, CreditLimit, UserName, Password, AccountNonExpired, AccountNonLocked, CredentialsNonExpired, Enabled, LastFailedLogin, FailedLoginCount, LastLoginDate, CreateDate, BirthDate, Hint, HintAnswer);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<BusinessCustomerService>.Current.Delete(recordId);
        }
        
    }
}
  