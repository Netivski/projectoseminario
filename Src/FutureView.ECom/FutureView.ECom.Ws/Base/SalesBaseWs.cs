
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
    public class SalesBaseWs : System.Web.Services.WebService
    {
            
        [WebMethod]
        public long Buy(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10)
        {                              
          return Singleton<SalesService>.Current.Buy(UserName, Password, ItemId1, ItemQty1, ItemId2, ItemQty2, ItemId3, ItemQty3, ItemId4, ItemQty4, ItemId5, ItemQty5, ItemId6, ItemQty6, ItemId7, ItemQty7, ItemId8, ItemQty8, ItemId9, ItemQty9, ItemId10, ItemQty10);
        }        
                                 
    }
}
  