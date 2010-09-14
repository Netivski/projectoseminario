
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
    public class TurmaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="TurmaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Turma record = new Turma(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetTurmaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="TurmaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            ITurmaDao dao = NHibernateDaoFactory.Current.GetTurmaDao();  

            Turma record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="TurmaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Turma Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetTurmaDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="TurmaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetTurmaDao().Delete( Read( recordId ) );
        }
    }
}
  