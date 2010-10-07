
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;

namespace FutureView.ECom.Entity.Domain
{
  [Serializable]
  public  class ShippingDomain : Address
  {
    public ShippingDomain () {}

    

    public override bool IsValid
    {
      get
      { 
        
        return true;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        return null;    
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Shipping obj)
    {
       return base.Equals((Address)obj);   
    }
  }
}
  