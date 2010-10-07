
using System;
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;


namespace FutureView.ECom.Services.Base
{
    public abstract class SalesBaseService
    {        
            
        #region - Buy
        protected virtual void BuyValidatePreCondition(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10)
        {
          
          if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
          {
            throw new PreConditionException<string>("Buy", "UserName", "CustomerUserName", UserName);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, Password) )
          {
            throw new PreConditionException<string>("Buy", "Password", "CustomerPassword", Password);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId1) )
          {
            throw new PreConditionException<long>("Buy", "ItemId1", "RecordId", ItemId1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty1) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty1", "OrderItemQty", ItemQty1);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId2) )
          {
            throw new PreConditionException<long>("Buy", "ItemId2", "RecordId", ItemId2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty2) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty2", "OrderItemQty", ItemQty2);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId3) )
          {
            throw new PreConditionException<long>("Buy", "ItemId3", "RecordId", ItemId3);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty3) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty3", "OrderItemQty", ItemQty3);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId4) )
          {
            throw new PreConditionException<long>("Buy", "ItemId4", "RecordId", ItemId4);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty4) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty4", "OrderItemQty", ItemQty4);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId5) )
          {
            throw new PreConditionException<long>("Buy", "ItemId5", "RecordId", ItemId5);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty5) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty5", "OrderItemQty", ItemQty5);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId6) )
          {
            throw new PreConditionException<long>("Buy", "ItemId6", "RecordId", ItemId6);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty6) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty6", "OrderItemQty", ItemQty6);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId7) )
          {
            throw new PreConditionException<long>("Buy", "ItemId7", "RecordId", ItemId7);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty7) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty7", "OrderItemQty", ItemQty7);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId8) )
          {
            throw new PreConditionException<long>("Buy", "ItemId8", "RecordId", ItemId8);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty8) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty8", "OrderItemQty", ItemQty8);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId9) )
          {
            throw new PreConditionException<long>("Buy", "ItemId9", "RecordId", ItemId9);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty9) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty9", "OrderItemQty", ItemQty9);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.RecordId, ItemId10) )
          {
            throw new PreConditionException<long>("Buy", "ItemId10", "RecordId", ItemId10);
          }
  
          if( !Validator.IsValid(UserTypeMetadata.OrderItemQty, ItemQty10) )
          {
            throw new PreConditionException<int>("Buy", "ItemQty10", "OrderItemQty", ItemQty10);
          }
  
        }
        
        protected abstract long  BuyLogic(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10);  
        
        
        protected virtual void BuyValidatePosCondition(long result)
        {
          if( !Validator.IsValid(UserTypeMetadata.RecordId, result) )
          {          
            throw new PosConditionException<long>("Buy", "RecordId", result);
          }
          }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BuyBaseService", MethodName="Buy", Unrestricted = false)] 
        public virtual long Buy(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10)
        {
          BuyValidatePreCondition(UserName, Password, ItemId1, ItemQty1, ItemId2, ItemQty2, ItemId3, ItemQty3, ItemId4, ItemQty4, ItemId5, ItemQty5, ItemId6, ItemQty6, ItemId7, ItemQty7, ItemId8, ItemQty8, ItemId9, ItemQty9, ItemId10, ItemQty10);
          long result = BuyLogic(UserName, Password, ItemId1, ItemQty1, ItemId2, ItemQty2, ItemId3, ItemQty3, ItemId4, ItemQty4, ItemId5, ItemQty5, ItemId6, ItemQty6, ItemId7, ItemQty7, ItemId8, ItemQty8, ItemId9, ItemQty9, ItemId10, ItemQty10);          
          BuyValidatePosCondition(result);
          return result;
                      
        }
        #endregion
           
    }
}
  