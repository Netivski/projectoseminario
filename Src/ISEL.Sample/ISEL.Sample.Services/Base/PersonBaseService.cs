﻿
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
    public class PersonBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PersonBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome)
        {
            Person record = new Person(){ Nome = Nome };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetPersonDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PersonBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome)
        {             
            IPersonDao dao = DaoFactory.Current.GetPersonDao();  

            Person record = dao.GetById(recordId, false);
            record.Nome = Nome;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PersonBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Person Read(long recordId)
        {
            return DaoFactory.Current.GetPersonDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PersonBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetPersonDao().Delete( Read( recordId ) );
        }
                        
    }
}
  