
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
    public class OrderItemBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, int Qty)
        {        
            return Singleton<OrderItemService>.Current.Create(Description, Available, Pvp, Discount, FinalPrice, IvaClass, DateToMarket, Weight, Qty);
        }

        [WebMethod]
        public void Update(long recordId, string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, int Qty)
        {
            Singleton<OrderItemService>.Current.Update(recordId, Description, Available, Pvp, Discount, FinalPrice, IvaClass, DateToMarket, Weight, Qty);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<OrderItemService>.Current.Delete(recordId);
        }
        
    }
}
  