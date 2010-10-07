
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
  public class PhoneBaseTest
    {
    private static PhoneService service = new PhoneService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreatePhone()
    {
      id = service.Create("Prefix", "Number");
      Assert.IsTrue(id != 0, "Unable to create a Phone");
    }
    
    [TestMethod]
    public void CanUpdatePhone()
    {      
      service.Update(id, "Prefix_2", "Number_2");
      Phone target = service.Read(id);
      
      Assert.AreEqual(target.Prefix, "Prefix_2");
      Assert.AreEqual(target.Number, "Number_2");
    }
    
    [TestMethod]
    public void CanReadPhone()
    {
      Phone target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Phone.");
    }
    
    
    [TestMethod]
    public void CanDeletePhone()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Phone");
    }
  }
}
  