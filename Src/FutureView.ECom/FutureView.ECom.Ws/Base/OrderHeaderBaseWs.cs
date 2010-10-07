
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
    public class OrderHeaderBaseWs : System.Web.Services.WebService
    {
        
        [WebMethod]
        public long Create(string ShipmentName, string ShipmentAddressline1, string ShipmentAddressline2, string ShipmentCountry, string ShipmentPostalCode, string ShipmentPostalCodeDesc, string BillingName, string BillingAddressLine1, string BillingAddressLine2, string BillingCountry, string BillingPostalCode, string BillingPostalCodeDesc, string BillingNif, decimal TotalAmount, decimal TotalWeight, int TotalItens, DateTime DateOfArrival, decimal DiscountAmount, string Obs, string StatusCode)
        {        
            return Singleton<OrderHeaderService>.Current.Create(ShipmentName, ShipmentAddressline1, ShipmentAddressline2, ShipmentCountry, ShipmentPostalCode, ShipmentPostalCodeDesc, BillingName, BillingAddressLine1, BillingAddressLine2, BillingCountry, BillingPostalCode, BillingPostalCodeDesc, BillingNif, TotalAmount, TotalWeight, TotalItens, DateOfArrival, DiscountAmount, Obs, StatusCode);
        }

        [WebMethod]
        public void Update(long recordId, string ShipmentName, string ShipmentAddressline1, string ShipmentAddressline2, string ShipmentCountry, string ShipmentPostalCode, string ShipmentPostalCodeDesc, string BillingName, string BillingAddressLine1, string BillingAddressLine2, string BillingCountry, string BillingPostalCode, string BillingPostalCodeDesc, string BillingNif, decimal TotalAmount, decimal TotalWeight, int TotalItens, DateTime DateOfArrival, decimal DiscountAmount, string Obs, string StatusCode)
        {
            Singleton<OrderHeaderService>.Current.Update(recordId, ShipmentName, ShipmentAddressline1, ShipmentAddressline2, ShipmentCountry, ShipmentPostalCode, ShipmentPostalCodeDesc, BillingName, BillingAddressLine1, BillingAddressLine2, BillingCountry, BillingPostalCode, BillingPostalCodeDesc, BillingNif, TotalAmount, TotalWeight, TotalItens, DateOfArrival, DiscountAmount, Obs, StatusCode);
        }

        [WebMethod]
        public void Delete(long recordId)
        {
            Singleton<OrderHeaderService>.Current.Delete(recordId);
        }
        
    }
}
  