﻿
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
  public class CustomerAddressBaseTest
    {
    private static CustomerAddressService service = new CustomerAddressService();
    private static long id = 0;
    
    [TestMethod]
    public void CanCreateCustomerAddress()
    {
      id = service.Create("Country", "Line1", "Line2", "PostalCode", "PostalCodeDesc");
      Assert.IsTrue(id != 0, "Unable to create a CustomerAddress");
    }
    
    [TestMethod]
    public void CanUpdateCustomerAddress()
    {      
      service.Update(id, "Country_2", "Line1_2", "Line2_2", "PostalCode_2", "PostalCodeDesc_2");
      CustomerAddress target = service.Read(id);
      
      Assert.AreEqual(target.Country, "Country_2");
      Assert.AreEqual(target.Line1, "Line1_2");
      Assert.AreEqual(target.Line2, "Line2_2");
      Assert.AreEqual(target.PostalCode, "PostalCode_2");
      Assert.AreEqual(target.PostalCodeDesc, "PostalCodeDesc_2");
    }
    
    [TestMethod]
    public void CanReadCustomerAddress()
    {
      CustomerAddress target = service.Read(id);
      Assert.IsNotNull(target, "Unable to read CustomerAddress.");
    }
    
    
    [TestMethod]
    public void CanDeleteCustomerAddress()
    {
      service.Delete(id);
      Assert.IsNull(service.Read(id), "Unable to delete CustomerAddress");
    }
  }
}
  