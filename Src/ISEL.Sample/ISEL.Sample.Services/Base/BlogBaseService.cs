
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
    public class BlogBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Blog record = new Blog(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetBlogDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            IBlogDao dao = DaoFactory.Current.GetBlogDao();  

            Blog record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Blog Read(long recordId)
        {
            return DaoFactory.Current.GetBlogDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetBlogDao().Delete( Read( recordId ) );
        }
                        
    }
}
  