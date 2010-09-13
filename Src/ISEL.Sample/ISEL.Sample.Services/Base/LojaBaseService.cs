
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class LojaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Loja record = new Loja(){ Nome = Nome };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetLojaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            ILojaDao dao = NHibernateDaoFactory.Current.GetLojaDao();  

            Loja record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Loja Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetLojaDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Loja ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetLojaDao().Delete( Read( recordId ) );
        }
    }
}
  