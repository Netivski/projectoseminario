
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
    public class PessoaBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<PessoaService>.Current.Create(Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<PessoaService>.Current.Update(recordId, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<PessoaService>.Current.Delete(recordId);
        }
    }
}
  