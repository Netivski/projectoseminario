
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
    public class AnoBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AnoBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(int Ano, string Semestre)
        {
            Ano record = new Ano(){ Ano = Ano, Semestre = Semestre };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetAnoDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AnoBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, int Ano, string Semestre)
        {             
            IAnoDao dao = DaoFactory.Current.GetAnoDao();  

            Ano record = dao.GetById(recordId, false);
            record.Ano = Ano;
            record.Semestre = Semestre;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AnoBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Ano Read(long recordId)
        {
            return DaoFactory.Current.GetAnoDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="AnoBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetAnoDao().Delete( Read( recordId ) );
        }
                        
    }
}
  