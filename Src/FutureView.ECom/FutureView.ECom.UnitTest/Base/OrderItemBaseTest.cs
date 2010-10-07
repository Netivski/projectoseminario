
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
  public class OrderItemBaseTest
    {
    private static OrderItemService service = new OrderItemService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateOrderItem()
    {
      id = service.Create("Description", true, 1, 1, 1, 1, new DateTime(2010, 1, 1), 1, 1);
      Assert.IsTrue(id != 0, "Unable to create a OrderItem");
    }
    
    [TestMethod]
    public void CanUpdateOrderItem()
    {      
      service.Update(id, "Description_2", false, 2, 2, 2, 2, new DateTime(2010, 2, 2), 2, 2);
      OrderItem target = service.Read(id);
      
      Assert.AreEqual(target.Description, "Description_2");
      Assert.AreEqual(target.Available, false);
      Assert.AreEqual(target.Pvp, 2);
      Assert.AreEqual(target.Discount, 2);
      Assert.AreEqual(target.FinalPrice, 2);
      Assert.AreEqual(target.IvaClass, 2);
      Assert.AreEqual(target.DateToMarket, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.Weight, 2);
      Assert.AreEqual(target.Qty, 2);
    }
    
    [TestMethod]
    public void CanReadOrderItem()
    {
      OrderItem target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read OrderItem.");
    }
    
    
    [TestMethod]
    public void CanDeleteOrderItem()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete OrderItem");
    }
  }
}
  