
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
  public class SkuBaseTest
    {
    private static SkuService service = new SkuService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateSku()
    {
      id = service.Create("Description", true, 1, 1, 1, 1, new DateTime(2010, 1, 1), 1, new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), 1, 1, "SmallImagePath", "LargeImagePath", 1, "SkuCode");
      Assert.IsTrue(id != 0, "Unable to create a Sku");
    }
    
    [TestMethod]
    public void CanUpdateSku()
    {      
      service.Update(id, "Description_2", false, 2, 2, 2, 2, new DateTime(2010, 2, 2), 2, new DateTime(2010, 2, 2), new DateTime(2010, 2, 2), 2, 2, "SmallImagePath_2", "LargeImagePath_2", 2, "SkuCode_2");
      Sku target = service.Read(id);
      
      Assert.AreEqual(target.Description, "Description_2");
      Assert.AreEqual(target.Available, false);
      Assert.AreEqual(target.Pvp, 2);
      Assert.AreEqual(target.Discount, 2);
      Assert.AreEqual(target.FinalPrice, 2);
      Assert.AreEqual(target.IvaClass, 2);
      Assert.AreEqual(target.DateToMarket, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.Weight, 2);
      Assert.AreEqual(target.EffectiveStartDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.EffectiveEndDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.MinOrderQty, 2);
      Assert.AreEqual(target.MaxOrderQty, 2);
      Assert.AreEqual(target.SmallImagePath, "SmallImagePath_2");
      Assert.AreEqual(target.LargeImagePath, "LargeImagePath_2");
      Assert.AreEqual(target.Qty, 2);
      Assert.AreEqual(target.SkuCode, "SkuCode_2");
    }
    
    [TestMethod]
    public void CanReadSku()
    {
      Sku target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Sku.");
    }
    
    
    [TestMethod]
    public void CanDeleteSku()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Sku");
    }
  }
}
  