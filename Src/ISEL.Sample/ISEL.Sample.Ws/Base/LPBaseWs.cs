
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
    public class LPBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(DateTime DtEdicao, string Titulo)
        {        
            return Singleton<LPService>.Current.Create(DtEdicao, Titulo);
        }

        [WebMethod]
        public void Update(long recordId, DateTime DtEdicao, string Titulo)
        {
            Singleton<LPService>.Current.Update(recordId, DtEdicao, Titulo);
        }

        [WebMethod]
        public LP Read(long recordId)
        {
            return Singleton<LPService>.Current.Read(recordId);
        }

        [WebMethod]
        public LP ReadByUnique()
        {
            return Singleton<LPService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<LPService>.Current.Delete(recordId);
        }
    }
}
  