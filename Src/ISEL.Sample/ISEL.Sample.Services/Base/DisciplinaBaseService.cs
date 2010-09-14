﻿
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
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
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetDisciplinaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            IDisciplinaDao dao = NHibernateDaoFactory.Current.GetDisciplinaDao();  

            Disciplina record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Disciplina Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDisciplinaDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Disciplina ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DisciplinaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDisciplinaDao().Delete( Read( recordId ) );
        }
    }
}
  