
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
    public class LojaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Loja record = new Loja(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetLojaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            ILojaDao dao = DaoFactory.Current.GetLojaDao();  

            Loja record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Loja Read(long recordId)
        {
            return DaoFactory.Current.GetLojaDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LojaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetLojaDao().Delete( Read( recordId ) );
        }
    }
}
  