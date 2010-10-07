
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
  public  class OrderHeaderDomain : DomainObject<long>, IEntity
  {
    public OrderHeaderDomain () {}

    
    IList<OrderItem> _Items = new List<OrderItem>();  
  
    public virtual string ShipmentName { get; set; }
  
    public virtual string ShipmentAddressline1 { get; set; }
  
    public virtual string ShipmentAddressline2 { get; set; }
  
    public virtual string ShipmentCountry { get; set; }
  
    public virtual string ShipmentPostalCode { get; set; }
  
    public virtual string ShipmentPostalCodeDesc { get; set; }
  
    public virtual string BillingName { get; set; }
  
    public virtual string BillingAddressLine1 { get; set; }
  
    public virtual string BillingAddressLine2 { get; set; }
  
    public virtual string BillingCountry { get; set; }
  
    public virtual string BillingPostalCode { get; set; }
  
    public virtual string BillingPostalCodeDesc { get; set; }
  
    public virtual string BillingNif { get; set; }
  
    public virtual decimal TotalAmount { get; set; }
  
    public virtual decimal TotalWeight { get; set; }
  
    public virtual int TotalItens { get; set; }
  
    public virtual DateTime DateOfArrival { get; set; }
  
    public virtual decimal DiscountAmount { get; set; }
  
    public virtual string Obs { get; set; }
  
    public virtual string StatusCode { get; set; }
  
    public virtual IList<OrderItem> Items {
        get { return new List<OrderItem>(_Items).AsReadOnly(); }
        protected set { _Items = value; }
    }     
  public  virtual Customer Customer { get; set; }
  
    public void AddOrderItem(OrderItem obj) {
        obj.OrderHeader = (OrderHeader)this;
        if (obj != null &&  !_Items.Contains(obj)) {
            _Items.Add(obj);
        }
    }

    public void RemoveOrderItem(OrderItem obj) {
        if (obj != null &&  _Items.Contains(obj)) {
            _Items.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentName, ShipmentName) && Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentAddressline1, ShipmentAddressline1) && Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentAddressline2, ShipmentAddressline2) && Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentCountry, ShipmentCountry) && Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentPostalCode, ShipmentPostalCode) && Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentPostalCodeDesc, ShipmentPostalCodeDesc) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingName, BillingName) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingAddressLine1, BillingAddressLine1) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingAddressLine2, BillingAddressLine2) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingCountry, BillingCountry) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingPostalCode, BillingPostalCode) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingPostalCodeDesc, BillingPostalCodeDesc) && Validator.IsValid(UserTypeMetadata.OrderHeaderBillingNif, BillingNif) && Validator.IsValid(UserTypeMetadata.OrderHeaderTotalAmount, TotalAmount) && Validator.IsValid(UserTypeMetadata.OrderHeaderTotalWeight, TotalWeight) && Validator.IsValid(UserTypeMetadata.OrderHeaderTotalItens, TotalItens) && Validator.IsValid(UserTypeMetadata.OrderHeaderDateOfArrival, DateOfArrival) && Validator.IsValid(UserTypeMetadata.OrderHeaderDiscountAmount, DiscountAmount) && Validator.IsValid(UserTypeMetadata.OrderHeaderObs, Obs) && Validator.IsValid(UserTypeMetadata.OrderHeaderStatusCode, StatusCode) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("OrderHeader");
        
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentName, ShipmentName) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentName", "OrderHeaderShipmentName", ShipmentName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentAddressline1, ShipmentAddressline1) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentAddressline1", "OrderHeaderShipmentAddressline1", ShipmentAddressline1) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentAddressline2, ShipmentAddressline2) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentAddressline2", "OrderHeaderShipmentAddressline2", ShipmentAddressline2) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentCountry, ShipmentCountry) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentCountry", "OrderHeaderShipmentCountry", ShipmentCountry) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentPostalCode, ShipmentPostalCode) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentPostalCode", "OrderHeaderShipmentPostalCode", ShipmentPostalCode) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderShipmentPostalCodeDesc, ShipmentPostalCodeDesc) )
        {
          ese.Add( new GeneralArgumentException<string>( "ShipmentPostalCodeDesc", "OrderHeaderShipmentPostalCodeDesc", ShipmentPostalCodeDesc) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingName, BillingName) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingName", "OrderHeaderBillingName", BillingName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingAddressLine1, BillingAddressLine1) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingAddressLine1", "OrderHeaderBillingAddressLine1", BillingAddressLine1) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingAddressLine2, BillingAddressLine2) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingAddressLine2", "OrderHeaderBillingAddressLine2", BillingAddressLine2) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingCountry, BillingCountry) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingCountry", "OrderHeaderBillingCountry", BillingCountry) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingPostalCode, BillingPostalCode) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingPostalCode", "OrderHeaderBillingPostalCode", BillingPostalCode) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingPostalCodeDesc, BillingPostalCodeDesc) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingPostalCodeDesc", "OrderHeaderBillingPostalCodeDesc", BillingPostalCodeDesc) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderBillingNif, BillingNif) )
        {
          ese.Add( new GeneralArgumentException<string>( "BillingNif", "OrderHeaderBillingNif", BillingNif) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderTotalAmount, TotalAmount) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "TotalAmount", "OrderHeaderTotalAmount", TotalAmount) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderTotalWeight, TotalWeight) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "TotalWeight", "OrderHeaderTotalWeight", TotalWeight) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderTotalItens, TotalItens) )
        {
          ese.Add( new GeneralArgumentException<int>( "TotalItens", "OrderHeaderTotalItens", TotalItens) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderDateOfArrival, DateOfArrival) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DateOfArrival", "OrderHeaderDateOfArrival", DateOfArrival) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderDiscountAmount, DiscountAmount) )
        {
          ese.Add( new GeneralArgumentException<decimal>( "DiscountAmount", "OrderHeaderDiscountAmount", DiscountAmount) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderObs, Obs) )
        {
          ese.Add( new GeneralArgumentException<string>( "Obs", "OrderHeaderObs", Obs) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.OrderHeaderStatusCode, StatusCode) )
        {
          ese.Add( new GeneralArgumentException<string>( "StatusCode", "OrderHeaderStatusCode", StatusCode) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(OrderHeader obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  