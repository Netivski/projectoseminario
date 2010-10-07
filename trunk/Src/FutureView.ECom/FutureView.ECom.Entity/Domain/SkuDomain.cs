
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
  public  class SkuDomain : DomainObject<long>, IEntity
  {
    public SkuDomain () {}

    
    IList<CategorySku> _CategorySku = new List<CategorySku>();  
  
    public virtual string Description { get; set; }
  
    public virtual bool Available { get; set; }
  
    public virtual decimal Pvp { get; set; }
  
    public virtual decimal Discount { get; set; }
  
    public virtual decimal FinalPrice { get; set; }
  
    public virtual decimal IvaClass { get; set; }
  
    public virtual DateTime DateToMarket { get; set; }
  
    public virtual decimal Weight { get; set; }
  
    public virtual DateTime EffectiveStartDate { get; set; }
  
    public virtual DateTime EffectiveEndDate { get; set; }
  
    public virtual int MinOrderQty { get; set; }
  
    public virtual int MaxOrderQty { get; set; }
  
    public virtual string SmallImagePath { get; set; }
  
    public virtual string LargeImagePath { get; set; }
  
    public virtual int Qty { get; set; }
  
    public virtual string SkuCode { get; set; }
  
    public virtual IList<CategorySku> CategorySku {
        get { return new List<CategorySku>(_CategorySku).AsReadOnly(); }
        protected set { _CategorySku = value; }
    }     
  
    public void AddCategorySku(CategorySku obj) {
        obj.Sku = (Sku)this;
        if (obj != null &&  !_CategorySku.Contains(obj)) {
            _CategorySku.Add(obj);
        }
    }

    public void RemoveCategorySku(CategorySku obj) {
        if (obj != null &&  _CategorySku.Contains(obj)) {
            _CategorySku.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.SkuDescription, Description) && Validator.IsValid(UserTypeMetadata.SkuAvailable, Available) && Validator.IsValid(UserTypeMetadata.SkuPvp, Pvp) && Validator.IsValid(UserTypeMetadata.SkuDiscount, Discount) && Validator.IsValid(UserTypeMetadata.SkuFinalPrice, FinalPrice) && Validator.IsValid(UserTypeMetadata.SkuIvaClass, IvaClass) && Validator.IsValid(UserTypeMetadata.SkuDateToMarket, DateToMarket) && Validator.IsValid(UserTypeMetadata.SkuWeight, Weight) && Validator.IsValid(UserTypeMetadata.SkuEffectiveStartDate, EffectiveStartDate) && Validator.IsValid(UserTypeMetadata.SkuEffectiveEndDate, EffectiveEndDate) && Validator.IsValid(UserTypeMetadata.SkuMinOrderQty, MinOrderQty) && Validator.IsValid(UserTypeMetadata.SkuMaxOrderQty, MaxOrderQty) && Validator.IsValid(UserTypeMetadata.SkuSmallImagePath, SmallImagePath) && Validator.IsValid(UserTypeMetadata.SkuLargeImagePath, LargeImagePath) && Validator.IsValid(UserTypeMetadata.SkuQty, Qty) && Validator.IsValid(UserTypeMetadata.SkuSkuCode, SkuCode) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Sku");
        
        if( !Validator.IsValid(UserTypeMetadata.SkuDescription, Description) )
        {
          ese.Add( new GeneralArgumentException<string>( "Description", "SkuDescription", Description) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuAvailable, Available) )
        {
          ese.Add( new GeneralArgumentException<bool>( "Available", "SkuAvailable", Available) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuPvp, Pvp) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Pvp", "SkuPvp", Pvp) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuDiscount, Discount) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Discount", "SkuDiscount", Discount) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuFinalPrice, FinalPrice) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "FinalPrice", "SkuFinalPrice", FinalPrice) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuIvaClass, IvaClass) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "IvaClass", "SkuIvaClass", IvaClass) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuDateToMarket, DateToMarket) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DateToMarket", "SkuDateToMarket", DateToMarket) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuWeight, Weight) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Weight", "SkuWeight", Weight) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuEffectiveStartDate, EffectiveStartDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "EffectiveStartDate", "SkuEffectiveStartDate", EffectiveStartDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuEffectiveEndDate, EffectiveEndDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "EffectiveEndDate", "SkuEffectiveEndDate", EffectiveEndDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuMinOrderQty, MinOrderQty) )
        {
          ese.Add( new GeneralArgumentException<int>( "MinOrderQty", "SkuMinOrderQty", MinOrderQty) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuMaxOrderQty, MaxOrderQty) )
        {
          ese.Add( new GeneralArgumentException<int>( "MaxOrderQty", "SkuMaxOrderQty", MaxOrderQty) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuSmallImagePath, SmallImagePath) )
        {
          ese.Add( new GeneralArgumentException<string>( "SmallImagePath", "SkuSmallImagePath", SmallImagePath) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuLargeImagePath, LargeImagePath) )
        {
          ese.Add( new GeneralArgumentException<string>( "LargeImagePath", "SkuLargeImagePath", LargeImagePath) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuQty, Qty) )
        {
          ese.Add( new GeneralArgumentException<int>( "Qty", "SkuQty", Qty) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.SkuSkuCode, SkuCode) )
        {
          ese.Add( new GeneralArgumentException<string>( "SkuCode", "SkuSkuCode", SkuCode) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Sku obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  