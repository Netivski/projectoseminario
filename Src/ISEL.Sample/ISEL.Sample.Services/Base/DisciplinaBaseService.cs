
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
    public class DisciplinaBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Disciplina record = new Disciplina(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetDisciplinaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            IDisciplinaDao dao = DaoFactory.Current.GetDisciplinaDao();  

            Disciplina record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Disciplina Read(long recordId)
        {
            return DaoFactory.Current.GetDisciplinaDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetDisciplinaDao().Delete( Read( recordId ) );
        }
                        
    }
}
  