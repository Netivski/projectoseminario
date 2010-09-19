
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using ISEL.Sample.Entity;
using ISEL.Sample.Services;

namespace ISEL.Sample.Ws.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class PostBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Name, DateTime CreateDt)
        {        
            return Singleton<PostService>.Current.Create(Name, CreateDt);
        }

        [WebMethod]
        public void Update(long recordId, string Name, DateTime CreateDt)
        {
            Singleton<PostService>.Current.Update(recordId, Name, CreateDt);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<PostService>.Current.Delete(recordId);
        }
        
    }
}
  