
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
    public class IndividualCustomerBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Nif, string FirstName, string LastName, string Title, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {        
            return Singleton<IndividualCustomerService>.Current.Create(Nif, FirstName, LastName, Title, UserName, Password, AccountNonExpired, AccountNonLocked, CredentialsNonExpired, Enabled, LastFailedLogin, FailedLoginCount, LastLoginDate, CreateDate, BirthDate, Hint, HintAnswer);
        }

        [WebMethod]
        public void Update(long recordId, string Nif, string FirstName, string LastName, string Title, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {
            Singleton<IndividualCustomerService>.Current.Update(recordId, Nif, FirstName, LastName, Title, UserName, Password, AccountNonExpired, AccountNonLocked, CredentialsNonExpired, Enabled, LastFailedLogin, FailedLoginCount, LastLoginDate, CreateDate, BirthDate, Hint, HintAnswer);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<IndividualCustomerService>.Current.Delete(recordId);
        }
        
    }
}
  