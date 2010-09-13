
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
    public class VendaBaseWs : System.Web.Services.WebService
    {
            
        [WebMethod]
        public string EncomendaCliente(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {                              
          return Singleton<VendaService>.Current.EncomendaCliente(tipoAlbum, idAlbum, canal, idCliente, encomendaQtd);
        }        
    
        [WebMethod]
        public string ObterEstadoEncomenda(string idEncomenda)
        {                              
          return Singleton<VendaService>.Current.ObterEstadoEncomenda(idEncomenda);
        }        
    
        [WebMethod]
        public string CancelarEncomenda(string idEncomenda)
        {                              
          return Singleton<VendaService>.Current.CancelarEncomenda(idEncomenda);
        }        
                                 
    }
}
  