
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
    public class LastPasswordBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LastPasswordBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Password, DateTime CreateDate)
        {
            LastPassword record = new LastPassword(){ Password = Password, CreateDate = CreateDate };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetLastPasswordDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LastPasswordBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Password, DateTime CreateDate)
        {             
            ILastPasswordDao dao = DaoFactory.Current.GetLastPasswordDao();  

            LastPassword record = dao.GetById(recordId, false);
            record.Password = Password;
            record.CreateDate = CreateDate;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LastPasswordBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual LastPassword Read(long recordId)
        {
            return DaoFactory.Current.GetLastPasswordDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LastPasswordBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetLastPasswordDao().Delete( Read( recordId ) );
        }
                        
    }
}
  