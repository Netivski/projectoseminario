
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
    public class RuntimeAuthorizationBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string TypeName, string MethodName)
        {        
            return Singleton<RuntimeAuthorizationService>.Current.Create(TypeName, MethodName);
        }

        [WebMethod]
        public void Update(long recordId, string TypeName, string MethodName)
        {
            Singleton<RuntimeAuthorizationService>.Current.Update(recordId, TypeName, MethodName);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<RuntimeAuthorizationService>.Current.Delete(recordId);
        }
        
    }
}
  