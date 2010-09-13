
using System;        
using EDM.FoundationClasses.Patterns;

namespace ISEL.Sample.Services
{
    public class RegistoService : Base.RegistoBaseService
    {        
          
        #region - RegistoCliente        
        protected override int RegistoClienteLogic(string userName, string password, string nomeCompleto, DateTime dtNascimento)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "RegistoClienteLogic" ));
        }
        #endregion
    
        #region - AlteracaoPassword        
        protected override string AlteracaoPasswordLogic(string userName, string passwordActual, string passwordFutura)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "AlteracaoPasswordLogic" ));
        }
        #endregion
           
    }
}
  