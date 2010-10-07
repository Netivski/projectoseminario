
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
  public class FixedPhoneBaseTest
    {
    private static FixedPhoneService service = new FixedPhoneService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateFixedPhone()
    {
      id = service.Create("Prefix", "Number");
      Assert.IsTrue(id != 0, "Unable to create a FixedPhone");
    }
    
    [TestMethod]
    public void CanUpdateFixedPhone()
    {      
      service.Update(id, "Prefix_2", "Number_2");
      FixedPhone target = service.Read(id);
      
      Assert.AreEqual(target.Prefix, "Prefix_2");
      Assert.AreEqual(target.Number, "Number_2");
    }
    
    [TestMethod]
    public void CanReadFixedPhone()
    {
      FixedPhone target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read FixedPhone.");
    }
    
    
    [TestMethod]
    public void CanDeleteFixedPhone()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete FixedPhone");
    }
  }
}
  