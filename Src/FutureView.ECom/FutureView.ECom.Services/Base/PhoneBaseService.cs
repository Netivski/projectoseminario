
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
    public class PhoneBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PhoneBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Prefix, string Number)
        {
            Phone record = new Phone(){ Prefix = Prefix, Number = Number };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetPhoneDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PhoneBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Prefix, string Number)
        {             
            IPhoneDao dao = DaoFactory.Current.GetPhoneDao();  

            Phone record = dao.GetById(recordId, false);
            record.Prefix = Prefix;
            record.Number = Number;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PhoneBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Phone Read(long recordId)
        {
            return DaoFactory.Current.GetPhoneDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PhoneBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetPhoneDao().Delete( Read( recordId ) );
        }
                        
    }
}
  