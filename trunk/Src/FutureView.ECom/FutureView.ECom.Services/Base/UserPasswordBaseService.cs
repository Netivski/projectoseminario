
using System;
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;


namespace FutureView.ECom.Services.Base
{
    public abstract class UserPasswordBaseService
    {        
            
        #region - ChangePassword
        protected virtual void ChangePasswordValidatePreCondition(string UserName, string OldPassword, string NewPassword)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
          {
            throw new PreConditionException<string>("ChangePassword", "UserName", "CustomerUserName", UserName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, OldPassword) )
          {
            throw new PreConditionException<string>("ChangePassword", "OldPassword", "CustomerPassword", OldPassword);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, NewPassword) )
          {
            throw new PreConditionException<string>("ChangePassword", "NewPassword", "CustomerPassword", NewPassword);
          }
  
        }
        
        protected abstract void  ChangePasswordLogic(string UserName, string OldPassword, string NewPassword);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ChangePasswordBaseService", MethodName="ChangePassword", Unrestricted = false)] 
        public virtual void ChangePassword(string UserName, string OldPassword, string NewPassword)
        {
          ChangePasswordValidatePreCondition(UserName, OldPassword, NewPassword);
          ChangePasswordLogic(UserName, OldPassword, NewPassword);          
        }
        #endregion
    
        #region - ResetPassword
        protected virtual void ResetPasswordValidatePreCondition(string UserName)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
          {
            throw new PreConditionException<string>("ResetPassword", "UserName", "CustomerUserName", UserName);
          }
  
        }
        
        protected abstract void  ResetPasswordLogic(string UserName);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ResetPasswordBaseService", MethodName="ResetPassword", Unrestricted = false)] 
        public virtual void ResetPassword(string UserName)
        {
          ResetPasswordValidatePreCondition(UserName);
          ResetPasswordLogic(UserName);          
        }
        #endregion
           
    }
}
  