
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
    public class OrderHeaderBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderHeaderBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string ShipmentName, string ShipmentAddressline1, string ShipmentAddressline2, string ShipmentCountry, string ShipmentPostalCode, string ShipmentPostalCodeDesc, string BillingName, string BillingAddressLine1, string BillingAddressLine2, string BillingCountry, string BillingPostalCode, string BillingPostalCodeDesc, string BillingNif, decimal TotalAmount, decimal TotalWeight, int TotalItens, DateTime DateOfArrival, decimal DiscountAmount, string Obs, string StatusCode)
        {
            OrderHeader record = new OrderHeader(){ ShipmentName = ShipmentName, ShipmentAddressline1 = ShipmentAddressline1, ShipmentAddressline2 = ShipmentAddressline2, ShipmentCountry = ShipmentCountry, ShipmentPostalCode = ShipmentPostalCode, ShipmentPostalCodeDesc = ShipmentPostalCodeDesc, BillingName = BillingName, BillingAddressLine1 = BillingAddressLine1, BillingAddressLine2 = BillingAddressLine2, BillingCountry = BillingCountry, BillingPostalCode = BillingPostalCode, BillingPostalCodeDesc = BillingPostalCodeDesc, BillingNif = BillingNif, TotalAmount = TotalAmount, TotalWeight = TotalWeight, TotalItens = TotalItens, DateOfArrival = DateOfArrival, DiscountAmount = DiscountAmount, Obs = Obs, StatusCode = StatusCode };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetOrderHeaderDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderHeaderBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string ShipmentName, string ShipmentAddressline1, string ShipmentAddressline2, string ShipmentCountry, string ShipmentPostalCode, string ShipmentPostalCodeDesc, string BillingName, string BillingAddressLine1, string BillingAddressLine2, string BillingCountry, string BillingPostalCode, string BillingPostalCodeDesc, string BillingNif, decimal TotalAmount, decimal TotalWeight, int TotalItens, DateTime DateOfArrival, decimal DiscountAmount, string Obs, string StatusCode)
        {             
            IOrderHeaderDao dao = DaoFactory.Current.GetOrderHeaderDao();  

            OrderHeader record = dao.GetById(recordId, false);
            record.ShipmentName = ShipmentName;
            record.ShipmentAddressline1 = ShipmentAddressline1;
            record.ShipmentAddressline2 = ShipmentAddressline2;
            record.ShipmentCountry = ShipmentCountry;
            record.ShipmentPostalCode = ShipmentPostalCode;
            record.ShipmentPostalCodeDesc = ShipmentPostalCodeDesc;
            record.BillingName = BillingName;
            record.BillingAddressLine1 = BillingAddressLine1;
            record.BillingAddressLine2 = BillingAddressLine2;
            record.BillingCountry = BillingCountry;
            record.BillingPostalCode = BillingPostalCode;
            record.BillingPostalCodeDesc = BillingPostalCodeDesc;
            record.BillingNif = BillingNif;
            record.TotalAmount = TotalAmount;
            record.TotalWeight = TotalWeight;
            record.TotalItens = TotalItens;
            record.DateOfArrival = DateOfArrival;
            record.DiscountAmount = DiscountAmount;
            record.Obs = Obs;
            record.StatusCode = StatusCode;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderHeaderBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual OrderHeader Read(long recordId)
        {
            return DaoFactory.Current.GetOrderHeaderDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="OrderHeaderBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetOrderHeaderDao().Delete( Read( recordId ) );
        }
                        
    }
}
  