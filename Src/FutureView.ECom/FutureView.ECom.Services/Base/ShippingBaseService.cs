
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
    public class ShippingBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ShippingBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {
            Shipping record = new Shipping(){ Country = Country, Line1 = Line1, Line2 = Line2, PostalCode = PostalCode, PostalCodeDesc = PostalCodeDesc };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetShippingDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ShippingBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {             
            IShippingDao dao = DaoFactory.Current.GetShippingDao();  

            Shipping record = dao.GetById(recordId, false);
            record.Country = Country;
            record.Line1 = Line1;
            record.Line2 = Line2;
            record.PostalCode = PostalCode;
            record.PostalCodeDesc = PostalCodeDesc;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ShippingBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Shipping Read(long recordId)
        {
            return DaoFactory.Current.GetShippingDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ShippingBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetShippingDao().Delete( Read( recordId ) );
        }
                        
    }
}
  