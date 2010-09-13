
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
    public class EditorBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome, string Pais)
        {        
            return Singleton<EditorService>.Current.Create(Nome, Pais);
        }

        [WebMethod]
        public void Update(long recordId, string Nome, string Pais)
        {
            Singleton<EditorService>.Current.Update(recordId, Nome, Pais);
        }

        [WebMethod]
        public Editor Read(long recordId)
        {
            return Singleton<EditorService>.Current.Read(recordId);
        }

        [WebMethod]
        public Editor ReadByUnique()
        {
            return Singleton<EditorService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<EditorService>.Current.Delete(recordId);
        }
    }
}
  