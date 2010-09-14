
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
    public class DirectorSegundaLinhaBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(int Antiguidade, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<DirectorSegundaLinhaService>.Current.Create(Antiguidade, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, int Antiguidade, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<DirectorSegundaLinhaService>.Current.Update(recordId, Antiguidade, LimiteCartaoCredito, LimiteAprovacao, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DirectorSegundaLinhaService>.Current.Delete(recordId);
        }
    }
}
  