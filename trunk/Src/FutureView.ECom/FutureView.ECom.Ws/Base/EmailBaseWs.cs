
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
    public class EmailBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Address, bool Enabled)
        {        
            return Singleton<EmailService>.Current.Create(Address, Enabled);
        }

        [WebMethod]
        public void Update(long recordId, string Address, bool Enabled)
        {
            Singleton<EmailService>.Current.Update(recordId, Address, Enabled);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<EmailService>.Current.Delete(recordId);
        }
        
    }
}
  