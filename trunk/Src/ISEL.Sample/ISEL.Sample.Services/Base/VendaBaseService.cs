
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
    public abstract class VendaBaseService
    {        
            
        #region - EncomendaCliente
        protected virtual void EncomendaClienteValidateParameters(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.tipoAlbum, tipoAlbum) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.identificador, idAlbum) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.canalVendas, canal) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.idCliente, idCliente) )
          {
            // throw new Ex .... 
          }
  
          if( !Validator.IsValid(UserTypeMetadata.encomendaQtd, encomendaQtd) )
          {
            // throw new Ex .... 
          }
  
        }
        
        protected abstract string EncomendaClienteLogic(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EncomendaClienteBaseService", MethodName="EncomendaCliente", Unrestricted = false)] 
        public virtual string EncomendaCliente(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {
          EncomendaClienteValidateParameters(tipoAlbum, idAlbum, canal, idCliente, encomendaQtd);
                    
          return EncomendaClienteLogic(tipoAlbum, idAlbum, canal, idCliente, encomendaQtd);
        }
        #endregion
    
        #region - ObterEstadoEncomenda
        protected virtual void ObterEstadoEncomendaValidateParameters(string idEncomenda)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.idEncomenda, idEncomenda) )
          {
            // throw new Ex .... 
          }
  
        }
        
        protected abstract string ObterEstadoEncomendaLogic(string idEncomenda);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ObterEstadoEncomendaBaseService", MethodName="ObterEstadoEncomenda", Unrestricted = false)] 
        public virtual string ObterEstadoEncomenda(string idEncomenda)
        {
          ObterEstadoEncomendaValidateParameters(idEncomenda);
                    
          return ObterEstadoEncomendaLogic(idEncomenda);
        }
        #endregion
    
        #region - CancelarEncomenda
        protected virtual void CancelarEncomendaValidateParameters(string idEncomenda)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.idEncomenda, idEncomenda) )
          {
            // throw new Ex .... 
          }
  
        }
        
        protected abstract string CancelarEncomendaLogic(string idEncomenda);  
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CancelarEncomendaBaseService", MethodName="CancelarEncomenda", Unrestricted = false)] 
        public virtual string CancelarEncomenda(string idEncomenda)
        {
          CancelarEncomendaValidateParameters(idEncomenda);
                    
          return CancelarEncomendaLogic(idEncomenda);
        }
        #endregion
           
    }
}
  