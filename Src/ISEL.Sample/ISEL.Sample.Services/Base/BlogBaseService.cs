
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
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
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetBlogDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            IBlogDao dao = NHibernateDaoFactory.Current.GetBlogDao();  

            Blog record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Blog Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetBlogDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Blog ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="BlogBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetBlogDao().Delete( Read( recordId ) );
        }
    }
}
  