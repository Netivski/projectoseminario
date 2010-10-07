
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
  public class IndividualCustomerBaseTest
    {
    private static IndividualCustomerService service = new IndividualCustomerService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateIndividualCustomer()
    {
      id = service.Create("Nif", "FirstName", "LastName", "Sr.", "UserName", "Password", true, true, true, true, true, 1, new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), "Hint", "HintAnswer");
      Assert.IsTrue(id != 0, "Unable to create a IndividualCustomer");
    }
    
    [TestMethod]
    public void CanUpdateIndividualCustomer()
    {      
      service.Update(id, "Nif_2", "FirstName_2", "LastName_2", "Eng.", "UserName_2", "Password_2", false, false, false, false, false, 2, new DateTime(2010, 2, 2), new DateTime(2010, 2, 2), new DateTime(2010, 2, 2), "Hint_2", "HintAnswer_2");
      IndividualCustomer target = service.Read(id);
      
      Assert.AreEqual(target.Nif, "Nif_2");
      Assert.AreEqual(target.FirstName, "FirstName_2");
      Assert.AreEqual(target.LastName, "LastName_2");
      Assert.AreEqual(target.Title, "Eng.");
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
    public void CanReadIndividualCustomer()
    {
      IndividualCustomer target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read IndividualCustomer.");
    }
    
    
    [TestMethod]
    public void CanDeleteIndividualCustomer()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete IndividualCustomer");
    }
  }
}
  