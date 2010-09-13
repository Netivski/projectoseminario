
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
    public class RegistoBaseWs : System.Web.Services.WebService
    {
            
        [WebMethod]
        public int RegistoCliente(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {                              
          return Singleton<RegistoService>.Current.RegistoCliente(userName, password, nomeCompleto, dtNascimento);
        }        
    
        [WebMethod]
        public string AlteracaoPassword(string userName, string passwordActual, string passwordFutura)
        {                              
          return Singleton<RegistoService>.Current.AlteracaoPassword(userName, passwordActual, passwordFutura);
        }        
                                 
    }
}
  