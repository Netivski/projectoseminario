
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
  public class LastPasswordBaseTest
    {
    private static LastPasswordService service = new LastPasswordService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateLastPassword()
    {
      id = service.Create("Password", new DateTime(2010, 1, 1));
      Assert.IsTrue(id != 0, "Unable to create a LastPassword");
    }
    
    [TestMethod]
    public void CanUpdateLastPassword()
    {      
      service.Update(id, "Password_2", new DateTime(2010, 2, 2));
      LastPassword target = service.Read(id);
      
      Assert.AreEqual(target.Password, "Password_2");
      Assert.AreEqual(target.CreateDate, new DateTime(2010, 2, 2));
    }
    
    [TestMethod]
    public void CanReadLastPassword()
    {
      LastPassword target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read LastPassword.");
    }
    
    
    [TestMethod]
    public void CanDeleteLastPassword()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete LastPassword");
    }
  }
}
  