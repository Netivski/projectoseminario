
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
    public class FaxBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaxBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Prefix, string Number)
        {
            Fax record = new Fax(){ Prefix = Prefix, Number = Number };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetFaxDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaxBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Prefix, string Number)
        {             
            IFaxDao dao = DaoFactory.Current.GetFaxDao();  

            Fax record = dao.GetById(recordId, false);
            record.Prefix = Prefix;
            record.Number = Number;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaxBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Fax Read(long recordId)
        {
            return DaoFactory.Current.GetFaxDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaxBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetFaxDao().Delete( Read( recordId ) );
        }
                        
    }
}
  