
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
  public class FaxBaseTest
    {
    private static FaxService service = new FaxService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateFax()
    {
      id = service.Create("Prefix", "Number");
      Assert.IsTrue(id != 0, "Unable to create a Fax");
    }
    
    [TestMethod]
    public void CanUpdateFax()
    {      
      service.Update(id, "Prefix_2", "Number_2");
      Fax target = service.Read(id);
      
      Assert.AreEqual(target.Prefix, "Prefix_2");
      Assert.AreEqual(target.Number, "Number_2");
    }
    
    [TestMethod]
    public void CanReadFax()
    {
      Fax target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read Fax.");
    }
    
    
    [TestMethod]
    public void CanDeleteFax()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete Fax");
    }
  }
}
  