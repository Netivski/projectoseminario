
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
    public class MobileBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="MobileBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Prefix, string Number)
        {
            Mobile record = new Mobile(){ Prefix = Prefix, Number = Number };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetMobileDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="MobileBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Prefix, string Number)
        {             
            IMobileDao dao = DaoFactory.Current.GetMobileDao();  

            Mobile record = dao.GetById(recordId, false);
            record.Prefix = Prefix;
            record.Number = Number;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="MobileBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Mobile Read(long recordId)
        {
            return DaoFactory.Current.GetMobileDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="MobileBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetMobileDao().Delete( Read( recordId ) );
        }
                        
    }
}
  