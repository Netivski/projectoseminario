
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.Data;

namespace FutureView.ECom.Services.Base
{
    public class SkuBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="SkuBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, DateTime EffectiveStartDate, DateTime EffectiveEndDate, int MinOrderQty, int MaxOrderQty, string SmallImagePath, string LargeImagePath, int Qty, string SkuCode)
        {
            Sku record = new Sku(){ Description = Description, Available = Available, Pvp = Pvp, Discount = Discount, FinalPrice = FinalPrice, IvaClass = IvaClass, DateToMarket = DateToMarket, Weight = Weight, EffectiveStartDate = EffectiveStartDate, EffectiveEndDate = EffectiveEndDate, MinOrderQty = MinOrderQty, MaxOrderQty = MaxOrderQty, SmallImagePath = SmallImagePath, LargeImagePath = LargeImagePath, Qty = Qty, SkuCode = SkuCode };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetSkuDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="SkuBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, DateTime EffectiveStartDate, DateTime EffectiveEndDate, int MinOrderQty, int MaxOrderQty, string SmallImagePath, string LargeImagePath, int Qty, string SkuCode)
        {             
            ISkuDao dao = DaoFactory.Current.GetSkuDao();  

            Sku record = dao.GetById(recordId, false);
            record.Description = Description;
            record.Available = Available;
            record.Pvp = Pvp;
            record.Discount = Discount;
            record.FinalPrice = FinalPrice;
            record.IvaClass = IvaClass;
            record.DateToMarket = DateToMarket;
            record.Weight = Weight;
            record.EffectiveStartDate = EffectiveStartDate;
            record.EffectiveEndDate = EffectiveEndDate;
            record.MinOrderQty = MinOrderQty;
            record.MaxOrderQty = MaxOrderQty;
            record.SmallImagePath = SmallImagePath;
            record.LargeImagePath = LargeImagePath;
            record.Qty = Qty;
            record.SkuCode = SkuCode;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="SkuBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Sku Read(long recordId)
        {
            return DaoFactory.Current.GetSkuDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="SkuBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetSkuDao().Delete( Read( recordId ) );
        }
                        
    }
}
  