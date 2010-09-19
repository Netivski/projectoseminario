
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
    public class CommentBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Content, DateTime CreateDt)
        {        
            return Singleton<CommentService>.Current.Create(Content, CreateDt);
        }

        [WebMethod]
        public void Update(long recordId, string Content, DateTime CreateDt)
        {
            Singleton<CommentService>.Current.Update(recordId, Content, CreateDt);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CommentService>.Current.Delete(recordId);
        }
        
    }
}
  