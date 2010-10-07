
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
    public class FixedPhoneBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FixedPhoneBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Prefix, string Number)
        {
            FixedPhone record = new FixedPhone(){ Prefix = Prefix, Number = Number };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetFixedPhoneDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FixedPhoneBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Prefix, string Number)
        {             
            IFixedPhoneDao dao = DaoFactory.Current.GetFixedPhoneDao();  

            FixedPhone record = dao.GetById(recordId, false);
            record.Prefix = Prefix;
            record.Number = Number;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FixedPhoneBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual FixedPhone Read(long recordId)
        {
            return DaoFactory.Current.GetFixedPhoneDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FixedPhoneBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetFixedPhoneDao().Delete( Read( recordId ) );
        }
                        
    }
}
  