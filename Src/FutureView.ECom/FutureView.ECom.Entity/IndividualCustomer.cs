
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using FutureView.ECom.Rtti;

namespace FutureView.ECom.Entity
{
  [Serializable]
  public  class IndividualCustomer : Domain.IndividualCustomerDomain
  {
    public IndividualCustomer () {}

    public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
  }
}
  