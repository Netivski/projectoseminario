
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
    public class MobileBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Prefix, string Number)
        {        
            return Singleton<MobileService>.Current.Create(Prefix, Number);
        }

        [WebMethod]
        public void Update(long recordId, string Prefix, string Number)
        {
            Singleton<MobileService>.Current.Update(recordId, Prefix, Number);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<MobileService>.Current.Delete(recordId);
        }
        
    }
}
  