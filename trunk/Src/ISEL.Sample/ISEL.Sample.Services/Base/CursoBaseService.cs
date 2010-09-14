
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
    public class CursoBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CursoBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Curso record = new Curso(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetCursoDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CursoBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            ICursoDao dao = NHibernateDaoFactory.Current.GetCursoDao();  

            Curso record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CursoBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Curso Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetCursoDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CursoBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetCursoDao().Delete( Read( recordId ) );
        }
    }
}
  