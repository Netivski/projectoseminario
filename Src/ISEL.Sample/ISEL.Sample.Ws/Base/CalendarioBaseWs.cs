
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
    public class CalendarioBaseWs : System.Web.Services.WebService
    {
        [WebMethod]
        public long Create(string HoraInicio, string HoraFim, string Sala)
        {        
            return Singleton<CalendarioService>.Current.Create(HoraInicio, HoraFim, Sala);
        }

        [WebMethod]
        public void Update(long recordId, string HoraInicio, string HoraFim, string Sala)
        {
            Singleton<CalendarioService>.Current.Update(recordId, HoraInicio, HoraFim, Sala);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<CalendarioService>.Current.Delete(recordId);
        }
    }
}
  