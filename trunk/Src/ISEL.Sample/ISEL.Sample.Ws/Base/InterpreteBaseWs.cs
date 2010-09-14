
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
    public class InterpreteBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome, string Nacionalidade)
        {        
            return Singleton<InterpreteService>.Current.Create(Nome, Nacionalidade);
        }

        [WebMethod]
        public void Update(long recordId, string Nome, string Nacionalidade)
        {
            Singleton<InterpreteService>.Current.Update(recordId, Nome, Nacionalidade);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<InterpreteService>.Current.Delete(recordId);
        }
    }
}
  