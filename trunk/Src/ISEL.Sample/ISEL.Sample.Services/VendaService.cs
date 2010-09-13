
using System;        
using EDM.FoundationClasses.Patterns;

namespace ISEL.Sample.Services
{
    public class VendaService : Base.VendaBaseService
    {        
          
        #region - EncomendaCliente        
        protected override string EncomendaClienteLogic(string tipoAlbum, int idAlbum, string canal, int idCliente, int encomendaQtd)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "EncomendaClienteLogic" ));
        }
        #endregion
    
        #region - ObterEstadoEncomenda        
        protected override string ObterEstadoEncomendaLogic(string idEncomenda)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "ObterEstadoEncomendaLogic" ));
        }
        #endregion
    
        #region - CancelarEncomenda        
        protected override string CancelarEncomendaLogic(string idEncomenda)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "CancelarEncomendaLogic" ));
        }
        #endregion
           
    }
}
  