
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
    public class SkuBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, int DateToMarket, decimal Weight, DateTime EffectiveStartDate, DateTime EffectiveEndDate, int MinOrderQty, int MaxOrderQty, string SmallImagePath, string LargeImagePath, int Qty, string SkuCode)
        {        
            return Singleton<SkuService>.Current.Create(Description, Available, Pvp, Discount, FinalPrice, IvaClass, DateToMarket, Weight, EffectiveStartDate, EffectiveEndDate, MinOrderQty, MaxOrderQty, SmallImagePath, LargeImagePath, Qty, SkuCode);
        }

        [WebMethod]
        public void Update(long recordId, string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, int DateToMarket, decimal Weight, DateTime EffectiveStartDate, DateTime EffectiveEndDate, int MinOrderQty, int MaxOrderQty, string SmallImagePath, string LargeImagePath, int Qty, string SkuCode)
        {
            Singleton<SkuService>.Current.Update(recordId, Description, Available, Pvp, Discount, FinalPrice, IvaClass, DateToMarket, Weight, EffectiveStartDate, EffectiveEndDate, MinOrderQty, MaxOrderQty, SmallImagePath, LargeImagePath, Qty, SkuCode);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<SkuService>.Current.Delete(recordId);
        }
        
    }
}
  