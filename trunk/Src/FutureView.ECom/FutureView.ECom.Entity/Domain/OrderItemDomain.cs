
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
  public  class OrderItemDomain : DomainObject<long>, IEntity
  {
    public OrderItemDomain () {}

    
    public virtual string Description { get; set; }
  
    public virtual bool Available { get; set; }
  
    public virtual decimal Pvp { get; set; }
  
    public virtual decimal Discount { get; set; }
  
    public virtual decimal FinalPrice { get; set; }
  
    public virtual decimal IvaClass { get; set; }
  
    public virtual DateTime DateToMarket { get; set; }
  
    public virtual decimal Weight { get; set; }
  
    public virtual int Qty { get; set; }
  public  virtual OrderHeader OrderHeader { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.OrderItemDescription, Description) && Validator.IsValid(UserTypeMetadata.OrderItemAvailable, Available) && Validator.IsValid(UserTypeMetadata.OrderItemPvp, Pvp) && Validator.IsValid(UserTypeMetadata.OrderItemDiscount, Discount) && Validator.IsValid(UserTypeMetadata.OrderItemFinalPrice, FinalPrice) && Validator.IsValid(UserTypeMetadata.OrderItemIvaClass, IvaClass) && Validator.IsValid(UserTypeMetadata.OrderItemDateToMarket, DateToMarket) && Validator.IsValid(UserTypeMetadata.OrderItemWeight, Weight) && Validator.IsValid(UserTypeMetadata.OrderItemQty, Qty) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("OrderItem");
        
        if( !Validator.IsValid(UserTypeMetadata.OrderItemDescription, Description) )
        {
          ese.Add( new GeneralArgumentException<string>( "Description", "OrderItemDescription", Description) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemAvailable, Available) )
        {
          ese.Add( new GeneralArgumentException<bool>( "Available", "OrderItemAvailable", Available) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemPvp, Pvp) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Pvp", "OrderItemPvp", Pvp) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemDiscount, Discount) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Discount", "OrderItemDiscount", Discount) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemFinalPrice, FinalPrice) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "FinalPrice", "OrderItemFinalPrice", FinalPrice) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemIvaClass, IvaClass) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "IvaClass", "OrderItemIvaClass", IvaClass) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemDateToMarket, DateToMarket) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DateToMarket", "OrderItemDateToMarket", DateToMarket) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemWeight, Weight) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "Weight", "OrderItemWeight", Weight) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, Qty) )
        {
          ese.Add( new GeneralArgumentException<int>( "Qty", "OrderItemQty", Qty) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(OrderItem obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  