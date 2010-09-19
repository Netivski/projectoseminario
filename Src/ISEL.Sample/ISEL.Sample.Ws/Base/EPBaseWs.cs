
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
    public class EPBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(DateTime DtLancamento, string Titulo)
        {        
            return Singleton<EPService>.Current.Create(DtLancamento, Titulo);
        }

        [WebMethod]
        public void Update(long recordId, DateTime DtLancamento, string Titulo)
        {
            Singleton<EPService>.Current.Update(recordId, DtLancamento, Titulo);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<EPService>.Current.Delete(recordId);
        }
        
    }
}
  