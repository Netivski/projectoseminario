
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
    public class ClienteBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(double CreditoMaximo, string Nome, DateTime DtNascimento, string NIF)
        {        
            return Singleton<ClienteService>.Current.Create(CreditoMaximo, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public void Update(long recordId, double CreditoMaximo, string Nome, DateTime DtNascimento, string NIF)
        {
            Singleton<ClienteService>.Current.Update(recordId, CreditoMaximo, Nome, DtNascimento, NIF);
        }

        [WebMethod]
        public Cliente Read(long recordId)
        {
            return Singleton<ClienteService>.Current.Read(recordId);
        }

        [WebMethod]
        public Cliente ReadByUnique()
        {
            return Singleton<ClienteService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<ClienteService>.Current.Delete(recordId);
        }
    }
}
  