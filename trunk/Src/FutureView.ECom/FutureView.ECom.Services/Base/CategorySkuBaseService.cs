
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
    public class CategorySkuBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategorySkuBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create()
        {
            CategorySku record = new CategorySku(){  };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetCategorySkuDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategorySkuBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId)
        {             
            ICategorySkuDao dao = DaoFactory.Current.GetCategorySkuDao();  

            CategorySku record = dao.GetById(recordId, false);            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategorySkuBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual CategorySku Read(long recordId)
        {
            return DaoFactory.Current.GetCategorySkuDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CategorySkuBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetCategorySkuDao().Delete( Read( recordId ) );
        }
                        
    }
}
  