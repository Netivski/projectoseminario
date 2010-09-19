
using System;
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using ISEL.Sample.Rtti;
using System.Collections.Generic;


namespace ISEL.Sample.Services.Base
{
    public abstract class RegistoBaseService
    {        
            
        #region - RegistoCliente
        protected virtual void RegistoClienteValidatePreCondition(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.userName, userName) )
          {
            throw new PreConditionException<string>("RegistoCliente", "userName", "userName", userName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, password) )
          {
            throw new PreConditionException<string>("RegistoCliente", "password", "password", password);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.nomeCompleto, nomeCompleto) )
          {
            throw new PreConditionException<string>("RegistoCliente", "nomeCompleto", "nomeCompleto", nomeCompleto);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.dtNascimento, dtNascimento) )
          {
            throw new PreConditionException<DateTime>("RegistoCliente", "dtNascimento", "dtNascimento", dtNascimento);
          }
  
        }
        
        protected abstract int  RegistoClienteLogic(string userName, string password, string nomeCompleto, DateTime dtNascimento);  
        
        
        protected virtual void RegistoClienteValidatePosCondition(int result)
        {
          if( !Validator.IsValid(UserTypeMetadata.idCliente, result) )
          {          
            throw new PosConditionException<int>("RegistoCliente", "idCliente", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RegistoClienteBaseService", MethodName="RegistoCliente", Unrestricted = false)] 
        public virtual int RegistoCliente(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {
          RegistoClienteValidatePreCondition(userName, password, nomeCompleto, dtNascimento);
          int result = RegistoClienteLogic(userName, password, nomeCompleto, dtNascimento);          
          RegistoClienteValidatePosCondition(result);
          return result;
                      
        }
        #endregion
    
        #region - AlteracaoPassword
        protected virtual void AlteracaoPasswordValidatePreCondition(string userName, string passwordActual, string passwordFutura)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.userName, userName) )
          {
            throw new PreConditionException<string>("AlteracaoPassword", "userName", "userName", userName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, passwordActual) )
          {
            throw new PreConditionException<string>("AlteracaoPassword", "passwordActual", "password", passwordActual);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.password, passwordFutura) )
          {
            throw new PreConditionException<string>("AlteracaoPassword", "passwordFutura", "password", passwordFutura);
          }
  
        }
        
        protected abstract string  AlteracaoPasswordLogic(string userName, string passwordActual, string passwordFutura);  
        
        
        protected virtual void AlteracaoPasswordValidatePosCondition(string result)
        {
          if( !Validator.IsValid(UserTypeMetadata.retornoAlteracaoPassword, result) )
          {          
            throw new PosConditionException<string>("AlteracaoPassword", "retornoAlteracaoPassword", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AlteracaoPasswordBaseService", MethodName="AlteracaoPassword", Unrestricted = false)] 
        public virtual string AlteracaoPassword(string userName, string passwordActual, string passwordFutura)
        {
          AlteracaoPasswordValidatePreCondition(userName, passwordActual, passwordFutura);
          string result = AlteracaoPasswordLogic(userName, passwordActual, passwordFutura);          
          AlteracaoPasswordValidatePosCondition(result);
          return result;
                      
        }
        #endregion
           
    }
}
  