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
          OrderHeader orderHeader = new OrderHeader();

          return 0;
      }
  }
}
  