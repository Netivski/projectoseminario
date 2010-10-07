
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
    public class UserPasswordBaseWs : System.Web.Services.WebService
    {
            
        [WebMethod]
        public void ChangePassword(string UserName, string OldPassword, string NewPassword)
        {                              
           Singleton<UserPasswordService>.Current.ChangePassword(UserName, OldPassword, NewPassword);
        }        
    
        [WebMethod]
        public void ResetPassword(string UserName)
        {                              
           Singleton<UserPasswordService>.Current.ResetPassword(UserName);
        }        
                                 
    }
}
  