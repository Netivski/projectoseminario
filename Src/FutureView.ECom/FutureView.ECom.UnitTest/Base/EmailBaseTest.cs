
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
  public class EmailBaseTest
    {
    private static EmailService service = new EmailService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateEmail()
    {
      id = service.Create("Address", true);
      Assert.IsTrue(id != 0, "Unable to create a Email");
    }
    
    [TestMethod]
    public void CanUpdateEmail()
    {      
      service.Update(id, "Address_2", false);
      Email target = service.Read(id);
      
      Assert.AreEqual(target.Address, "Address_2");
      Assert.AreEqual(target.Enabled, false);
    }
    
    [TestMethod]
    public void CanReadEmail()
    {
      Email target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Email.");
    }
    
    
    [TestMethod]
    public void CanDeleteEmail()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Email");
    }
  }
}
  