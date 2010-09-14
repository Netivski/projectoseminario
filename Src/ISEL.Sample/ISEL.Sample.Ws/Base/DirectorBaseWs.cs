
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
    public class DirectorBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<DirectorService>.Current.Create(LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<DirectorService>.Current.Update(recordId, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DirectorService>.Current.Delete(recordId);
        }
    }
}
  