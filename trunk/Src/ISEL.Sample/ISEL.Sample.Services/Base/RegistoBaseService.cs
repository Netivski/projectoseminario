
using System;  
using System.Security.Permissions;
using System.Security;
using System.Collections.Generic;
using EDM.FoundationClasses.Security.Permissions; 
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;


namespace ISEL.Sample.Services.Base
{
    public abstract class RegistoBaseService
    {        
            
        #region - RegistoCliente
        protected virtual void RegistoClienteValidateParameters(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.userName, userName) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, password) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.nomeCompleto, nomeCompleto) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.dtNascimento, dtNascimento) )
          {
            // throw new Ex .... 
          }
  
        }
        
        protected abstract int RegistoClienteLogic(string userName, string password, string nomeCompleto, DateTime dtNascimento);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RegistoClienteBaseService", MethodName="RegistoCliente", Unrestricted = false)] 
        public virtual int RegistoCliente(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {
          RegistoClienteValidateParameters(userName, password, nomeCompleto, dtNascimento);
                    
          return RegistoClienteLogic(userName, password, nomeCompleto, dtNascimento);
        }
        #endregion
    
        #region - AlteracaoPassword
        protected virtual void AlteracaoPasswordValidateParameters(string userName, string passwordActual, string passwordFutura)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.userName, userName) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, passwordActual) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, passwordFutura) )
          {
            // throw new Ex .... 
          }
  
        }
        
        protected abstract string AlteracaoPasswordLogic(string userName, string passwordActual, string passwordFutura);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlteracaoPasswordBaseService", MethodName="AlteracaoPassword", Unrestricted = false)] 
        public virtual string AlteracaoPassword(string userName, string passwordActual, string passwordFutura)
        {
          AlteracaoPasswordValidateParameters(userName, passwordActual, passwordFutura);
                    
          return AlteracaoPasswordLogic(userName, passwordActual, passwordFutura);
        }
        #endregion
           
    }
}
  