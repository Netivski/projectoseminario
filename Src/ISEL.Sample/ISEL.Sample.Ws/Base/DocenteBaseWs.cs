
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
    public class DocenteBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Nome, int Numero)
        {        
            return Singleton<DocenteService>.Current.Create(Nome, Numero);
        }

        [WebMethod]
        public void Update(long recordId, string Nome, int Numero)
        {
            Singleton<DocenteService>.Current.Update(recordId, Nome, Numero);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DocenteService>.Current.Delete(recordId);
        }
        
    }
}
  