
using System;        
using EDM.FoundationClasses.Patterns;

namespace FutureView.ECom.Services.Base
{
    public class SalesBaseImplementationService : SalesBaseService
    {        
          
        #region - Buy        
        protected override long BuyLogic(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10)
        {
          throw new NotImplementedException( string.Format("Method {0} not Implemented", "BuyLogic" ));
        }
        #endregion
           
    }
}
  