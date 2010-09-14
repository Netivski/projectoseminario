
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
    public class DirectorPrimeiraLinhaBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string NomeDepartamento, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<DirectorPrimeiraLinhaService>.Current.Create(NomeDepartamento, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, string NomeDepartamento, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<DirectorPrimeiraLinhaService>.Current.Update(recordId, NomeDepartamento, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DirectorPrimeiraLinhaService>.Current.Delete(recordId);
        }
    }
}
  