
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
  public class BusinessCustomerBaseTest
    {
    private static BusinessCustomerService service = new BusinessCustomerService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateBusinessCustomer()
    {
      id = service.Create("Nif", "Name", 1, 1, "UserName", "Password", true, true, true, true, true, 1, new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), "Hint", "HintAnswer");
      Assert.IsTrue(id != 0, "Unable to create a BusinessCustomer");
    }
    
    [TestMethod]
    public void CanUpdateBusinessCustomer()
    {      
      service.Update(id, "Nif_2", "Name_2", 2, 2, "UserName_2", "Password_2", false, false, false, false, false, 2, new DateTime(2010, 2, 2), new DateTime(2010, 2, 2), new DateTime(2010, 2, 2), "Hint_2", "HintAnswer_2");
      BusinessCustomer target = service.Read(id);
      
      Assert.AreEqual(target.Nif, "Nif_2");
      Assert.AreEqual(target.Name, "Name_2");
      Assert.AreEqual(target.Capital, 2);
      Assert.AreEqual(target.CreditLimit, 2);
      Assert.AreEqual(target.UserName, "UserName_2");
      Assert.AreEqual(target.Password, "Password_2");
      Assert.AreEqual(target.AccountNonExpired, false);
      Assert.AreEqual(target.AccountNonLocked, false);
      Assert.AreEqual(target.CredentialsNonExpired, false);
      Assert.AreEqual(target.Enabled, false);
      Assert.AreEqual(target.LastFailedLogin, false);
      Assert.AreEqual(target.FailedLoginCount, 2);
      Assert.AreEqual(target.LastLoginDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.CreateDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.BirthDate, new DateTime(2010, 2, 2));
      Assert.AreEqual(target.Hint, "Hint_2");
      Assert.AreEqual(target.HintAnswer, "HintAnswer_2");
    }
    
    [TestMethod]
    public void CanReadBusinessCustomer()
    {
      BusinessCustomer target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read BusinessCustomer.");
    }
    
    
    [TestMethod]
    public void CanDeleteBusinessCustomer()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete BusinessCustomer");
    }
  }
}
  