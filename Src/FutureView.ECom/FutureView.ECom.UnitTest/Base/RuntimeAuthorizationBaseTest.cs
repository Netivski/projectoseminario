
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
  public class RuntimeAuthorizationBaseTest
    {
    private static RuntimeAuthorizationService service = new RuntimeAuthorizationService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateRuntimeAuthorization()
    {
      id = service.Create("TypeName", "MethodName");
      Assert.IsTrue(id != 0, "Unable to create a RuntimeAuthorization");
    }
    
    [TestMethod]
    public void CanUpdateRuntimeAuthorization()
    {      
      service.Update(id, "TypeName_2", "MethodName_2");
      RuntimeAuthorization target = service.Read(id);
      
      Assert.AreEqual(target.TypeName, "TypeName_2");
      Assert.AreEqual(target.MethodName, "MethodName_2");
    }
    
    [TestMethod]
    public void CanReadRuntimeAuthorization()
    {
      RuntimeAuthorization target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read RuntimeAuthorization.");
    }
    
    
    [TestMethod]
    public void CanDeleteRuntimeAuthorization()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete RuntimeAuthorization");
    }
  }
}
  