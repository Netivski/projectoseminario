
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
    public class DisciplinaBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Nome)
        {        
            return Singleton<DisciplinaService>.Current.Create(Nome);
        }

        [WebMethod]
        public void Update(long recordId, string Nome)
        {
            Singleton<DisciplinaService>.Current.Update(recordId, Nome);
        }

        [WebMethod]
        public Disciplina Read(long recordId)
        {
            return Singleton<DisciplinaService>.Current.Read(recordId);
        }

        [WebMethod]
        public Disciplina ReadByUnique()
        {
            return Singleton<DisciplinaService>.Current.ReadByUnique();
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<DisciplinaService>.Current.Delete(recordId);
        }
    }
}
  