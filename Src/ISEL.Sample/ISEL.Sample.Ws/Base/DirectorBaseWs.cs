
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
        public long Create(double LimiteCartaoCredito, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<DirectorService>.Current.Create(LimiteCartaoCredito, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, double LimiteCartaoCredito, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<DirectorService>.Current.Update(recordId, LimiteCartaoCredito, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public Director Read(long recordId)
        {
            return Singleton<DirectorService>.Current.Read(recordId);
        }

        [WebMethod]
        public Director ReadByUnique()
        {
            return Singleton<DirectorService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DirectorService>.Current.Delete(recordId);
        }
    }
}
  