
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
    public class AlbumBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string Titulo)
        {        
            return Singleton<AlbumService>.Current.Create(Titulo);
        }

        [WebMethod]
        public void Update(long recordId, string Titulo)
        {
            Singleton<AlbumService>.Current.Update(recordId, Titulo);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<AlbumService>.Current.Delete(recordId);
        }
    }
}
  