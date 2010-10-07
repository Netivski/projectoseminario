
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
    public class RuntimeAuthorizationUserBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationUserBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string UserName)
        {
            RuntimeAuthorizationUser record = new RuntimeAuthorizationUser(){ UserName = UserName };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetRuntimeAuthorizationUserDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationUserBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string UserName)
        {             
            IRuntimeAuthorizationUserDao dao = DaoFactory.Current.GetRuntimeAuthorizationUserDao();  

            RuntimeAuthorizationUser record = dao.GetById(recordId, false);
            record.UserName = UserName;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationUserBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual RuntimeAuthorizationUser Read(long recordId)
        {
            return DaoFactory.Current.GetRuntimeAuthorizationUserDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="RuntimeAuthorizationUserBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetRuntimeAuthorizationUserDao().Delete( Read( recordId ) );
        }
                        
    }
}
  