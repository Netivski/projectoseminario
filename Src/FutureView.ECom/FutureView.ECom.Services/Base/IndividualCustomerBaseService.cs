﻿
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.Data;

namespace FutureView.ECom.Services.Base
{
    public class IndividualCustomerBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="IndividualCustomerBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nif, string FirstName, string LastName, string Title, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {
            IndividualCustomer record = new IndividualCustomer(){ Nif = Nif, FirstName = FirstName, LastName = LastName, Title = Title, UserName = UserName, Password = Password, AccountNonExpired = AccountNonExpired, AccountNonLocked = AccountNonLocked, CredentialsNonExpired = CredentialsNonExpired, Enabled = Enabled, LastFailedLogin = LastFailedLogin, FailedLoginCount = FailedLoginCount, LastLoginDate = LastLoginDate, CreateDate = CreateDate, BirthDate = BirthDate, Hint = Hint, HintAnswer = HintAnswer };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetIndividualCustomerDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="IndividualCustomerBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nif, string FirstName, string LastName, string Title, string UserName, string Password, bool AccountNonExpired, bool AccountNonLocked, bool CredentialsNonExpired, bool Enabled, bool LastFailedLogin, int FailedLoginCount, DateTime LastLoginDate, DateTime CreateDate, DateTime BirthDate, string Hint, string HintAnswer)
        {             
            IIndividualCustomerDao dao = DaoFactory.Current.GetIndividualCustomerDao();  

            IndividualCustomer record = dao.GetById(recordId, false);
            record.UserName = UserName;
            record.Password = Password;
            record.AccountNonExpired = AccountNonExpired;
            record.AccountNonLocked = AccountNonLocked;
            record.CredentialsNonExpired = CredentialsNonExpired;
            record.Enabled = Enabled;
            record.LastFailedLogin = LastFailedLogin;
            record.FailedLoginCount = FailedLoginCount;
            record.LastLoginDate = LastLoginDate;
            record.CreateDate = CreateDate;
            record.BirthDate = BirthDate;
            record.Hint = Hint;
            record.HintAnswer = HintAnswer;
            record.Nif = Nif;
            record.FirstName = FirstName;
            record.LastName = LastName;
            record.Title = Title;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="IndividualCustomerBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual IndividualCustomer Read(long recordId)
        {
            return DaoFactory.Current.GetIndividualCustomerDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="IndividualCustomerBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetIndividualCustomerDao().Delete( Read( recordId ) );
        }
                        
    }
}
  