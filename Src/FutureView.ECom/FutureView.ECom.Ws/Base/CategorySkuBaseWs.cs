
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
    public class CategorySkuBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create()
        {        
            return Singleton<CategorySkuService>.Current.Create();
        }

        [WebMethod]
        public void Update(long recordId)
        {
            Singleton<CategorySkuService>.Current.Update(recordId);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CategorySkuService>.Current.Delete(recordId);
        }
        
    }
}
  