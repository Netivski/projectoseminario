
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
  public class CategoryBaseTest
    {
    private static CategoryService service = new CategoryService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateCategory()
    {
      id = service.Create("Name", "Description", "SmallImagePath", "LargeImagePath", new DateTime(2010, 1, 1), new DateTime(2010, 1, 1));
      Assert.IsTrue(id != 0, "Unable to create a Category");
    }
    
    [TestMethod]
    public void CanUpdateCategory()
    {      
      service.Update(id, "Name_2", "Description_2", "SmallImagePath_2", "LargeImagePath_2", new DateTime(2010, 2, 2), new DateTime(2010, 2, 2));
      Category target = service.Read(id);
      
      Assert.AreEqual(target.Name, "Name_2");
      Assert.AreEqual(target.Description, "Description_2");
      Assert.AreEqual(target.SmallImagePath, "SmallImagePath_2");
      Assert.AreEqual(target.LargeImagePath, "LargeImagePath_2");
      Assert.AreEqual(target.EffectiveStartDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.EffectiveEndDate, new DateTime(2010, 2, 2));
    }
    
    [TestMethod]
    public void CanReadCategory()
    {
      Category target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Category.");
    }
    
    
    [TestMethod]
    public void CanDeleteCategory()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Category");
    }
  }
}
  