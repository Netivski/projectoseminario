
using System;        
using EDM.FoundationClasses.Patterns;

namespace FutureView.ECom.Services.Base
{
    public class UserPasswordBaseImplementationService : UserPasswordBaseService
    {        
          
        #region - ChangePassword        
        protected override void ChangePasswordLogic(string UserName, string OldPassword, string NewPassword)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "ChangePasswordLogic" ));
        }
        #endregion
    
        #region - ResetPassword        
        protected override void ResetPasswordLogic(string UserName)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "ResetPasswordLogic" ));
        }
        #endregion
           
    }
}
  