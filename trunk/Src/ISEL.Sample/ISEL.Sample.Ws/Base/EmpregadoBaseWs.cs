
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
    public class EmpregadoBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<EmpregadoService>.Current.Create(Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<EmpregadoService>.Current.Update(recordId, Numero, DtAdmissao, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public Empregado Read(long recordId)
        {
            return Singleton<EmpregadoService>.Current.Read(recordId);
        }

        [WebMethod]
        public Empregado ReadByUnique()
        {
            return Singleton<EmpregadoService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<EmpregadoService>.Current.Delete(recordId);
        }
    }
}
  