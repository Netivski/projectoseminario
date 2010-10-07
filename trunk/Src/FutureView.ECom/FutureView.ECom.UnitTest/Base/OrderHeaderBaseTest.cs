
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FutureView.ECom.Entity;
using FutureView.ECom.Services;

namespace FutureView.ECom.UnitTest.Base
{
  [TestClass]
  public class OrderHeaderBaseTest
    {
    private static OrderHeaderService service = new OrderHeaderService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateOrderHeader()
    {
      id = service.Create("ShipmentName", "ShipmentAddressline1", "ShipmentAddressline2", "ShipmentCountry", "ShipmentPostalCode", "ShipmentPostalCodeDesc", "BillingName", "BillingAddressLine1", "BillingAddressLine2", "BillingCountry", "BillingPostalCode", "BillingPostalCodeDesc", "BillingNif", 1, 1, 1, new DateTime(2010, 1, 1), 1, "Obs", "Created");
      Assert.IsTrue(id != 0, "Unable to create a OrderHeader");
    }
    
    [TestMethod]
    public void CanUpdateOrderHeader()
    {      
      service.Update(id, "ShipmentName_2", "ShipmentAddressline1_2", "ShipmentAddressline2_2", "ShipmentCountry_2", "ShipmentPostalCode_2", "ShipmentPostalCodeDesc_2", "BillingName_2", "BillingAddressLine1_2", "BillingAddressLine2_2", "BillingCountry_2", "BillingPostalCode_2", "BillingPostalCodeDesc_2", "BillingNif_2", 2, 2, 2, new DateTime(2010, 2, 2), 2, "Obs_2", "Submited");
      OrderHeader target = service.Read(id);
      
      Assert.AreEqual(target.ShipmentName, "ShipmentName_2");
      Assert.AreEqual(target.ShipmentAddressline1, "ShipmentAddressline1_2");
      Assert.AreEqual(target.ShipmentAddressline2, "ShipmentAddressline2_2");
      Assert.AreEqual(target.ShipmentCountry, "ShipmentCountry_2");
      Assert.AreEqual(target.ShipmentPostalCode, "ShipmentPostalCode_2");
      Assert.AreEqual(target.ShipmentPostalCodeDesc, "ShipmentPostalCodeDesc_2");
      Assert.AreEqual(target.BillingName, "BillingName_2");
      Assert.AreEqual(target.BillingAddressLine1, "BillingAddressLine1_2");
      Assert.AreEqual(target.BillingAddressLine2, "BillingAddressLine2_2");
      Assert.AreEqual(target.BillingCountry, "BillingCountry_2");
      Assert.AreEqual(target.BillingPostalCode, "BillingPostalCode_2");
      Assert.AreEqual(target.BillingPostalCodeDesc, "BillingPostalCodeDesc_2");
      Assert.AreEqual(target.BillingNif, "BillingNif_2");
      Assert.AreEqual(target.TotalAmount, 2);
      Assert.AreEqual(target.TotalWeight, 2);
      Assert.AreEqual(target.TotalItens, 2);
      Assert.AreEqual(target.DateOfArrival, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.DiscountAmount, 2);
      Assert.AreEqual(target.Obs, "Obs_2");
      Assert.AreEqual(target.StatusCode, "Submited");
    }
    
    [TestMethod]
    public void CanReadOrderHeader()
    {
      OrderHeader target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read OrderHeader.");
    }
    
    
    [TestMethod]
    public void CanDeleteOrderHeader()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete OrderHeader");
    }
  }
}
  