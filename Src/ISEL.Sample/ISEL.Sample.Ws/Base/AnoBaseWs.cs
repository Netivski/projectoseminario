
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
    public class AnoBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(int Ano, string Semestre)
        {        
            return Singleton<AnoService>.Current.Create(Ano, Semestre);
        }

        [WebMethod]
        public void Update(long recordId, int Ano, string Semestre)
        {
            Singleton<AnoService>.Current.Update(recordId, Ano, Semestre);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<AnoService>.Current.Delete(recordId);
        }
    }
}
  