
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
    public class RuntimeAuthorizationBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string TypeName, string MethodName)
        {
            RuntimeAuthorization record = new RuntimeAuthorization(){ TypeName = TypeName, MethodName = MethodName };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetRuntimeAuthorizationDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string TypeName, string MethodName)
        {             
            IRuntimeAuthorizationDao dao = DaoFactory.Current.GetRuntimeAuthorizationDao();  

            RuntimeAuthorization record = dao.GetById(recordId, false);
            record.TypeName = TypeName;
            record.MethodName = MethodName;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual RuntimeAuthorization Read(long recordId)
        {
            return DaoFactory.Current.GetRuntimeAuthorizationDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetRuntimeAuthorizationDao().Delete( Read( recordId ) );
        }
                        
    }
}
  