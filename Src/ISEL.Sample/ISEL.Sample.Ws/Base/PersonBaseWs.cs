
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
    public class PersonBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome)
        {        
            return Singleton<PersonService>.Current.Create(Nome);
        }

        [WebMethod]
        public void Update(long recordId, string Nome)
        {
            Singleton<PersonService>.Current.Update(recordId, Nome);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<PersonService>.Current.Delete(recordId);
        }
    }
}
  