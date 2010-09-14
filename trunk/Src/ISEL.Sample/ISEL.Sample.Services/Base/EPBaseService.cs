
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class EPBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EPBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(DateTime DtLancamento, string Titulo)
        {
            EP record = new EP(){ Titulo = Titulo, DtLancamento = DtLancamento };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetEPDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EPBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, DateTime DtLancamento, string Titulo)
        {             
            IEPDao dao = NHibernateDaoFactory.Current.GetEPDao();  

            EP record = dao.GetById(recordId, false);
            record.Titulo = Titulo;
            record.DtLancamento = DtLancamento;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EPBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual EP Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetEPDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EPBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetEPDao().Delete( Read( recordId ) );
        }
    }
}
  