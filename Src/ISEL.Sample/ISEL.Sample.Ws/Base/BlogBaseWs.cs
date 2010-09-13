
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
    public class BlogBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome)
        {        
            return Singleton<BlogService>.Current.Create(Nome);
        }

        [WebMethod]
        public void Update(long recordId, string Nome)
        {
            Singleton<BlogService>.Current.Update(recordId, Nome);
        }

        [WebMethod]
        public Blog Read(long recordId)
        {
            return Singleton<BlogService>.Current.Read(recordId);
        }

        [WebMethod]
        public Blog ReadByUnique()
        {
            return Singleton<BlogService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<BlogService>.Current.Delete(recordId);
        }
    }
}
  