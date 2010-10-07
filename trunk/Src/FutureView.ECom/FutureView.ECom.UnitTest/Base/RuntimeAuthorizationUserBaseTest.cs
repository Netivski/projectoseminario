
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
  public class RuntimeAuthorizationUserBaseTest
    {
    private static RuntimeAuthorizationUserService service = new RuntimeAuthorizationUserService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateRuntimeAuthorizationUser()
    {
      id = service.Create("UserName");
      Assert.IsTrue(id != 0, "Unable to create a RuntimeAuthorizationUser");
    }
    
    [TestMethod]
    public void CanUpdateRuntimeAuthorizationUser()
    {      
      service.Update(id, "UserName_2");
      RuntimeAuthorizationUser target = service.Read(id);
      
      Assert.AreEqual(target.UserName, "UserName_2");
    }
    
    [TestMethod]
    public void CanReadRuntimeAuthorizationUser()
    {
      RuntimeAuthorizationUser target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read RuntimeAuthorizationUser.");
    }
    
    
    [TestMethod]
    public void CanDeleteRuntimeAuthorizationUser()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete RuntimeAuthorizationUser");
    }
  }
}
  