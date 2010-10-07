
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
  public class CategorySkuBaseTest
    {
    private static CategorySkuService service = new CategorySkuService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateCategorySku()
    {
      id = service.Create();
      Assert.IsTrue(id != 0, "Unable to create a CategorySku");
    }
    
    [TestMethod]
    public void CanUpdateCategorySku()
    {      
      service.Update(id);
      CategorySku target = service.Read(id);
      
    }
    
    [TestMethod]
    public void CanReadCategorySku()
    {
      CategorySku target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read CategorySku.");
    }
    
    
    [TestMethod]
    public void CanDeleteCategorySku()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete CategorySku");
    }
  }
}
  