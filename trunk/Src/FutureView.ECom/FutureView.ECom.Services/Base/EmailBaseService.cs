
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
    public class EmailBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmailBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Address, bool Enabled)
        {
            Email record = new Email(){ Address = Address, Enabled = Enabled };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetEmailDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmailBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Address, bool Enabled)
        {             
            IEmailDao dao = DaoFactory.Current.GetEmailDao();  

            Email record = dao.GetById(recordId, false);
            record.Address = Address;
            record.Enabled = Enabled;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmailBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Email Read(long recordId)
        {
            return DaoFactory.Current.GetEmailDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmailBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetEmailDao().Delete( Read( recordId ) );
        }
                        
    }
}
  