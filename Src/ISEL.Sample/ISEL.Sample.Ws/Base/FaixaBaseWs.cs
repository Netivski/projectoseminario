
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
    public class FaixaBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Nome, string Duracao, string Genero)
        {        
            return Singleton<FaixaService>.Current.Create(Nome, Duracao, Genero);
        }

        [WebMethod]
        public void Update(long recordId, string Nome, string Duracao, string Genero)
        {
            Singleton<FaixaService>.Current.Update(recordId, Nome, Duracao, Genero);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<FaixaService>.Current.Delete(recordId);
        }
        
    }
}
  