using System;
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using EDM.FoundationClasses.Exception.FoundationType;
using ISEL.Sample.Entity;
using ISEL.Sample.Services;
    
namespace ISEL.Sample.Ws
{
    public class VendaWs : Base.VendaBaseWs
    {
        [WebMethod]
        public string ObterEstadoEncomendaII(string idEncomenda)
        {
            try
            {
                return Singleton<VendaService>.Current.ObterEstadoEncomenda(idEncomenda);

            }
            catch (GeneralArgumentException<string> e)
            {
                return e.Message;
            }
        }        

    }
}    
  