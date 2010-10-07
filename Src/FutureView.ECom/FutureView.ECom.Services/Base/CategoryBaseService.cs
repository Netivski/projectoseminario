
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using FutureView.ECom.Entity;
using FutureView.ECom.Entity.DataInterfaces;
using FutureView.ECom.Entity.Data;

namespace FutureView.ECom.Services.Base
{
    public class CategoryBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategoryBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Name, string Description, string SmallImagePath, string LargeImagePath, DateTime EffectiveStartDate, DateTime EffectiveEndDate)
        {
            Category record = new Category(){ Name = Name, Description = Description, SmallImagePath = SmallImagePath, LargeImagePath = LargeImagePath, EffectiveStartDate = EffectiveStartDate, EffectiveEndDate = EffectiveEndDate };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetCategoryDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategoryBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Name, string Description, string SmallImagePath, string LargeImagePath, DateTime EffectiveStartDate, DateTime EffectiveEndDate)
        {             
            ICategoryDao dao = DaoFactory.Current.GetCategoryDao();  

            Category record = dao.GetById(recordId, false);
            record.Name = Name;
            record.Description = Description;
            record.SmallImagePath = SmallImagePath;
            record.LargeImagePath = LargeImagePath;
            record.EffectiveStartDate = EffectiveStartDate;
            record.EffectiveEndDate = EffectiveEndDate;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategoryBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Category Read(long recordId)
        {
            return DaoFactory.Current.GetCategoryDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategoryBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetCategoryDao().Delete( Read( recordId ) );
        }
                        
    }
}
  