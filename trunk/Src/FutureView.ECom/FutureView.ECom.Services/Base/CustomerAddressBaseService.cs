
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
    public class CustomerAddressBaseService
    {   
       
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CustomerAddressBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {
            CustomerAddress record = new CustomerAddress(){ Country = Country, Line1 = Line1, Line2 = Line2, PostalCode = PostalCode, PostalCodeDesc = PostalCodeDesc };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetCustomerAddressDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CustomerAddressBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Country, string Line1, string Line2, string PostalCode, string PostalCodeDesc)
        {             
            ICustomerAddressDao dao = DaoFactory.Current.GetCustomerAddressDao();  

            CustomerAddress record = dao.GetById(recordId, false);
            record.Country = Country;
            record.Line1 = Line1;
            record.Line2 = Line2;
            record.PostalCode = PostalCode;
            record.PostalCodeDesc = PostalCodeDesc;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CustomerAddressBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual CustomerAddress Read(long recordId)
        {
            return DaoFactory.Current.GetCustomerAddressDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="CustomerAddressBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetCustomerAddressDao().Delete( Read( recordId ) );
        }
                        
    }
}
  