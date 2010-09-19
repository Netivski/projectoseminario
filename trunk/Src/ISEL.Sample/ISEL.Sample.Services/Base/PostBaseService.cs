
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using ISEL.Sample.Rtti;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class PostBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PostBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Name, DateTime CreateDt)
        {
            Post record = new Post(){ Name = Name, CreateDt = CreateDt };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetPostDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PostBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Name, DateTime CreateDt)
        {             
            IPostDao dao = DaoFactory.Current.GetPostDao();  

            Post record = dao.GetById(recordId, false);
            record.Name = Name;
            record.CreateDt = CreateDt;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PostBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Post Read(long recordId)
        {
            return DaoFactory.Current.GetPostDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PostBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetPostDao().Delete( Read( recordId ) );
        }
                        
    }
}
  