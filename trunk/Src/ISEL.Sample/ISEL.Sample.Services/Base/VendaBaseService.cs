
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
    public abstract class VendaBaseService
    {        
            
        #region - BpTest
        protected virtual void BpTestValidatePreCondition()
        {
          
        }
        
        protected abstract void  BpTestLogic();  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BpTestBaseService", MethodName="BpTest", Unrestricted = false)] 
        public virtual void BpTest()
        {
          BpTestValidatePreCondition();
          BpTestLogic();          
        }
        #endregion
    
        #region - EncomendaCliente
        protected virtual void EncomendaClienteValidatePreCondition(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.tipoAlbum, tipoAlbum) )
          {
            throw new PreConditionException<string>("EncomendaCliente", "tipoAlbum", "tipoAlbum", tipoAlbum);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.identificador, idAlbum) )
          {
            throw new PreConditionException<int>("EncomendaCliente", "idAlbum", "identificador", idAlbum);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.canalVendas, canal) )
          {
            throw new PreConditionException<string>("EncomendaCliente", "canal", "canalVendas", canal);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.idCliente, idCliente) )
          {
            throw new PreConditionException<int>("EncomendaCliente", "idCliente", "idCliente", idCliente);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.encomendaQtd, encomendaQtd) )
          {
            throw new PreConditionException<int>("EncomendaCliente", "encomendaQtd", "encomendaQtd", encomendaQtd);
          }
  
        }
        
        protected abstract string  EncomendaClienteLogic(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd);  
        
        
        protected virtual void EncomendaClienteValidatePosCondition(string result)
        {
          if( !Validator.IsValid(UserTypeMetadata.idEncomenda, result) )
          {          
            throw new PosConditionException<string>("EncomendaCliente", "idEncomenda", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EncomendaClienteBaseService", MethodName="EncomendaCliente", Unrestricted = false)] 
        public virtual string EncomendaCliente(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {
          EncomendaClienteValidatePreCondition(tipoAlbum, idAlbum, canal, idCliente, encomendaQtd);
          string result = EncomendaClienteLogic(tipoAlbum, idAlbum, canal, idCliente, encomendaQtd);          
          EncomendaClienteValidatePosCondition(result);
          return result;
                      
        }
        #endregion
    
        #region - ObterEstadoEncomenda
        protected virtual void ObterEstadoEncomendaValidatePreCondition(string idEncomenda)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.idEncomenda, idEncomenda) )
          {
            throw new PreConditionException<string>("ObterEstadoEncomenda", "idEncomenda", "idEncomenda", idEncomenda);
          }
  
        }
        
        protected abstract string  ObterEstadoEncomendaLogic(string idEncomenda);  
        
        
        protected virtual void ObterEstadoEncomendaValidatePosCondition(string result)
        {
          if( !Validator.IsValid(UserTypeMetadata.estadoEncomenda, result) )
          {          
            throw new PosConditionException<string>("ObterEstadoEncomenda", "estadoEncomenda", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ObterEstadoEncomendaBaseService", MethodName="ObterEstadoEncomenda", Unrestricted = false)] 
        public virtual string ObterEstadoEncomenda(string idEncomenda)
        {
          ObterEstadoEncomendaValidatePreCondition(idEncomenda);
          string result = ObterEstadoEncomendaLogic(idEncomenda);          
          ObterEstadoEncomendaValidatePosCondition(result);
          return result;
                      
        }
        #endregion
    
        #region - CancelarEncomenda
        protected virtual void CancelarEncomendaValidatePreCondition(string idEncomenda)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.idEncomenda, idEncomenda) )
          {
            throw new PreConditionException<string>("CancelarEncomenda", "idEncomenda", "idEncomenda", idEncomenda);
          }
  
        }
        
        protected abstract string  CancelarEncomendaLogic(string idEncomenda);  
        
        
        protected virtual void CancelarEncomendaValidatePosCondition(string result)
        {
          if( !Validator.IsValid(UserTypeMetadata.retornoCancelarEncomenda, result) )
          {          
            throw new PosConditionException<string>("CancelarEncomenda", "retornoCancelarEncomenda", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CancelarEncomendaBaseService", MethodName="CancelarEncomenda", Unrestricted = false)] 
        public virtual string CancelarEncomenda(string idEncomenda)
        {
          CancelarEncomendaValidatePreCondition(idEncomenda);
          string result = CancelarEncomendaLogic(idEncomenda);          
          CancelarEncomendaValidatePosCondition(result);
          return result;
                      
        }
        #endregion
           
    }
}
  