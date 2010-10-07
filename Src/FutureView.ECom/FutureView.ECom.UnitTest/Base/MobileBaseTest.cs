
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
  public class MobileBaseTest
    {
    private static MobileService service = new MobileService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateMobile()
    {
      id = service.Create("Prefix", "Number");
      Assert.IsTrue(id != 0, "Unable to create a Mobile");
    }
    
    [TestMethod]
    public void CanUpdateMobile()
    {      
      service.Update(id, "Prefix_2", "Number_2");
      Mobile target = service.Read(id);
      
      Assert.AreEqual(target.Prefix, "Prefix_2");
      Assert.AreEqual(target.Number, "Number_2");
    }
    
    [TestMethod]
    public void CanReadMobile()
    {
      Mobile target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Mobile.");
    }
    
    
    [TestMethod]
    public void CanDeleteMobile()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Mobile");
    }
  }
}
  