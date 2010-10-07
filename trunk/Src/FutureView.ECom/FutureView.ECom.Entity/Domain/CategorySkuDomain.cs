
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
  public  class CategorySkuDomain : DomainObject<long>, IEntity
  {
    public CategorySkuDomain () {}

    public  virtual Category Category { get; set; }
  public  virtual Sku Sku { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return true;
          
      }
    }
    
    public virtual EntityStateException StateException
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

        
    public bool Equals(CategorySku obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  