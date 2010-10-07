using System;
using System.Linq;
using System.Collections.Generic;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.Data;
using FutureView.ECom.Entity.DataInterfaces;

namespace FutureView.ECom.Services
{
  public class SalesService : Base.SalesBaseImplementationService
  {
      public override long Buy(string UserName, string Password, long ItemId1, int ItemQty1, long ItemId2, int ItemQty2, long ItemId3, int ItemQty3, long ItemId4, int ItemQty4, long ItemId5, int ItemQty5, long ItemId6, int ItemQty6, long ItemId7, int ItemQty7, long ItemId8, int ItemQty8, long ItemId9, int ItemQty9, long ItemId10, int ItemQty10)
      {
          ICustomerDao customerDao = DaoFactory.Current.GetCustomerDao();
          Customer customer = customerDao.GetByUserNameAndPassword(UserName, Password );

          if (customer == null) throw new ApplicationException("Invalid Customer");

          Dictionary<long, int> items = new Dictionary<long, int>();
          items.Add(ItemId1, ItemQty1);
          if (items.Keys.Contains(ItemId2)) items[ItemId2] += ItemQty2; else items.Add(ItemId2, ItemQty2);
          if (items.Keys.Contains(ItemId3)) items[ItemId3] += ItemQty3; else items.Add(ItemId3, ItemQty3);
          if (items.Keys.Contains(ItemId4)) items[ItemId4] += ItemQty4; else items.Add(ItemId4, ItemQty4);
          if (items.Keys.Contains(ItemId5)) items[ItemId5] += ItemQty5; else items.Add(ItemId5, ItemQty5);
          if (items.Keys.Contains(ItemId6)) items[ItemId6] += ItemQty6; else items.Add(ItemId6, ItemQty6);
          if (items.Keys.Contains(ItemId7)) items[ItemId7] += ItemQty7; else items.Add(ItemId7, ItemQty7);
          if (items.Keys.Contains(ItemId8)) items[ItemId8] += ItemQty8; else items.Add(ItemId8, ItemQty8);
          if (items.Keys.Contains(ItemId9)) items[ItemId9] += ItemQty9; else items.Add(ItemId9, ItemQty9);

          OrderHeader orderHeader = new OrderHeader() { DateOfArrival = DateTime.Now.AddDays(3), Obs = "eCom", StatusCode = "Created" };
          Contact contact = (Billing)customer.GetContactByType(typeof(Billing));
          if (contact != null)
          {
              orderHeader.BillingAddressLine1 = ((Shipping)contact).Line1;
              orderHeader.BillingAddressLine2 = ((Shipping)contact).Line2;
              orderHeader.BillingCountry = ((Shipping)contact).Country;
              orderHeader.BillingName = ( customer is IndividualCustomer ? ((IndividualCustomer)customer).FullName : ((BusinessCustomer)customer).Name);
              orderHeader.BillingPostalCode = ((Shipping)contact).PostalCode;
              orderHeader.BillingPostalCodeDesc = ((Shipping)contact).PostalCodeDesc;
          }

          contact = (Shipping)customer.GetContactByType(typeof(Shipping));
          if (contact != null)
          {
              orderHeader.ShipmentAddressline1 = ((Shipping)contact).Line1;
              orderHeader.ShipmentAddressline2 = ((Shipping)contact).Line2;
              orderHeader.ShipmentCountry = ((Shipping)contact).Country;
              orderHeader.ShipmentName = (customer is IndividualCustomer ? ((IndividualCustomer)customer).FullName : ((BusinessCustomer)customer).Name);
              orderHeader.ShipmentPostalCode = ((Shipping)contact).PostalCode;
              orderHeader.ShipmentPostalCodeDesc = ((Shipping)contact).PostalCodeDesc;
          }

          ISkuDao skuDao = DaoFactory.Current.GetSkuDao();
          foreach( long skuId in items.Keys )
          {             
              Sku sku = skuDao.GetById(skuId, false);
              orderHeader.TotalItens += 1;
              orderHeader.TotalAmount += sku.FinalPrice * items[skuId];
              orderHeader.TotalWeight += sku.Weight * items[skuId];
             
              orderHeader.AddOrderItem( new OrderItem() { Available = sku.Available, DateToMarket = sku.DateToMarket, Description = sku.Description, Discount = sku.Discount, FinalPrice = sku.FinalPrice, IvaClass = sku.IvaClass, Pvp = sku.Pvp, Qty = items[skuId], Weight = sku.Weight } );
          }
                    
          return DaoFactory.Current.GetOrderHeaderDao().SaveOrUpdate( orderHeader ).ID;
      }
  }
}
  