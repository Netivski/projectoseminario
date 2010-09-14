
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
    public class InterpreteBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, string Nacionalidade)
        {
            Interprete record = new Interprete(){ Nome = Nome, Nacionalidade = Nacionalidade };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetInterpreteDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, string Nacionalidade)
        {             
            IInterpreteDao dao = DaoFactory.Current.GetInterpreteDao();  

            Interprete record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.Nacionalidade = Nacionalidade;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Interprete Read(long recordId)
        {
            return DaoFactory.Current.GetInterpreteDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetInterpreteDao().Delete( Read( recordId ) );
        }
    }
}
  