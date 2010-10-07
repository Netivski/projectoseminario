
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
    public class OrderItemBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderItemBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, int Qty)
        {
            OrderItem record = new OrderItem(){ Description = Description, Available = Available, Pvp = Pvp, Discount = Discount, FinalPrice = FinalPrice, IvaClass = IvaClass, DateToMarket = DateToMarket, Weight = Weight, Qty = Qty };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetOrderItemDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderItemBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Description, bool Available, decimal Pvp, decimal Discount, decimal FinalPrice, decimal IvaClass, DateTime DateToMarket, decimal Weight, int Qty)
        {             
            IOrderItemDao dao = DaoFactory.Current.GetOrderItemDao();  

            OrderItem record = dao.GetById(recordId, false);
            record.Description = Description;
            record.Available = Available;
            record.Pvp = Pvp;
            record.Discount = Discount;
            record.FinalPrice = FinalPrice;
            record.IvaClass = IvaClass;
            record.DateToMarket = DateToMarket;
            record.Weight = Weight;
            record.Qty = Qty;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderItemBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual OrderItem Read(long recordId)
        {
            return DaoFactory.Current.GetOrderItemDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderItemBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetOrderItemDao().Delete( Read( recordId ) );
        }
                        
    }
}
  