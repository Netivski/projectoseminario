
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
    public class CalendarioBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CalendarioBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string HoraInicio, string HoraFim, string Sala)
        {
            Calendario record = new Calendario(){ HoraInicio = HoraInicio, HoraFim = HoraFim, Sala = Sala };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetCalendarioDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CalendarioBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string HoraInicio, string HoraFim, string Sala)
        {             
            ICalendarioDao dao = NHibernateDaoFactory.Current.GetCalendarioDao();  

            Calendario record = dao.GetById(recordId, false);
            record.HoraInicio = HoraInicio;
            record.HoraFim = HoraFim;
            record.Sala = Sala;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CalendarioBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Calendario Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetCalendarioDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CalendarioBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetCalendarioDao().Delete( Read( recordId ) );
        }
    }
}
  