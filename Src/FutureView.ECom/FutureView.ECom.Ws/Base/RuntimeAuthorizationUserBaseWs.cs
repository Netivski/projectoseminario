
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
    public class RuntimeAuthorizationUserBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string UserName)
        {        
            return Singleton<RuntimeAuthorizationUserService>.Current.Create(UserName);
        }

        [WebMethod]
        public void Update(long recordId, string UserName)
        {
            Singleton<RuntimeAuthorizationUserService>.Current.Update(recordId, UserName);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<RuntimeAuthorizationUserService>.Current.Delete(recordId);
        }
        
    }
}
  