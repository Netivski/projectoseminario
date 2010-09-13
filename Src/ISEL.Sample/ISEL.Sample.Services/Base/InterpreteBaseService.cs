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
    public class InterpreteBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, string Nacionalidade)
        {
            Interprete record = new Interprete(){ Nome = Nome, Nacionalidade = Nacionalidade };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetInterpreteDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, string Nacionalidade)
        {             
            IInterpreteDao dao = NHibernateDaoFactory.Current.GetInterpreteDao();  

            Interprete record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.Nacionalidade = Nacionalidade;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Interprete Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetInterpreteDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Interprete ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="InterpreteBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetInterpreteDao().Delete( Read( recordId ) );
        }
    }
}
  