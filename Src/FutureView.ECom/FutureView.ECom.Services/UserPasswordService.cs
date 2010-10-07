using System;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.Data;
using FutureView.ECom.Entity.DataInterfaces;

namespace FutureView.ECom.Services
{
  public class UserPasswordService : Base.UserPasswordBaseImplementationService
  {
      protected override void ChangePasswordLogic(string UserName, string OldPassword, string NewPassword)
      {
          ICustomerDao customerDao = DaoFactory.Current.GetCustomerDao();
          Customer customer = customerDao.GetByUserName(UserName);

          if (customer == null)                                        throw new ApplicationException( "Invalid Customer" );
          if ( string.Compare( customer.Password, OldPassword ) != 0 ) throw new ApplicationException( "Invalid Customer Password" );
          foreach (LastPassword lp in customer.LastPasswords) if (string.Compare(lp.Password, NewPassword) == 0) throw new ApplicationException("Invalid Customer Password. ( Password Already Exists )");

          customer.LastPasswords.Add(new LastPassword() { Password = customer.Password });
          customer.Password = NewPassword;

          customerDao.SaveOrUpdate(customer);
      }

      protected override void ResetPasswordLogic(string UserName)
      {
          ICustomerDao customerDao = DaoFactory.Current.GetCustomerDao();
          Customer customer = customerDao.GetByUserName(UserName);

          if (customer == null) throw new ApplicationException("Invalid Customer");
          customer.Password = Guid.NewGuid().ToString();

          Email eMail = (Email)customer.GetContactByType(typeof(Email));
          if (eMail == null) throw new ApplicationException( "Invalid Customer Configuration ( EMail )" );
          Util.EMail.EMailSender.SendMail(new Util.EMail.Template.ResetPassword(), eMail.Address, customer.Password);

          customerDao.SaveOrUpdate(customer);
      }
  }
}
  