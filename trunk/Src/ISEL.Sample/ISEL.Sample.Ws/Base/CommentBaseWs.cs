
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
        public long Create(string Content, DateTime Create)
        {        
            return Singleton<CommentService>.Current.Create(Content, Create);
        }

        [WebMethod]
        public void Update(long recordId, string Content, DateTime Create)
        {
            Singleton<CommentService>.Current.Update(recordId, Content, Create);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CommentService>.Current.Delete(recordId);
        }
    }
}
  