
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
    public class DocenteBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DocenteBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, int Numero)
        {
            Docente record = new Docente(){ Nome = Nome, Numero = Numero };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetDocenteDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DocenteBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, int Numero)
        {             
            IDocenteDao dao = NHibernateDaoFactory.Current.GetDocenteDao();  

            Docente record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.Numero = Numero;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DocenteBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Docente Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDocenteDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DocenteBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDocenteDao().Delete( Read( recordId ) );
        }
    }
}
  