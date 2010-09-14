
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
    public class LPBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LPBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(DateTime DtEdicao, string Titulo)
        {
            LP record = new LP(){ Titulo = Titulo, DtEdicao = DtEdicao };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetLPDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LPBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, DateTime DtEdicao, string Titulo)
        {             
            ILPDao dao = NHibernateDaoFactory.Current.GetLPDao();  

            LP record = dao.GetById(recordId, false);
            record.Titulo = Titulo;
            record.DtEdicao = DtEdicao;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LPBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual LP Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetLPDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="LPBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetLPDao().Delete( Read( recordId ) );
        }
    }
}
  