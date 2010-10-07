
using System;    
using System.Web.Services;
using EDM.FoundationClasses.Patterns;
using FutureView.ECom.Entity;
using FutureView.ECom.Services;

namespace FutureView.ECom.Ws.Base
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class LastPasswordBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Password, DateTime CreateDate)
        {        
            return Singleton<LastPasswordService>.Current.Create(Password, CreateDate);
        }

        [WebMethod]
        public void Update(long recordId, string Password, DateTime CreateDate)
        {
            Singleton<LastPasswordService>.Current.Update(recordId, Password, CreateDate);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<LastPasswordService>.Current.Delete(recordId);
        }
        
    }
}
  