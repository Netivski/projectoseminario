
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class ClienteBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ClienteBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(double CreditoMaximo, string Nome, DateTime DtNascimento, string NIF)
        {
            Cliente record = new Cliente(){ Nome = Nome, DtNascimento = DtNascimento, NIF = NIF, CreditoMaximo = CreditoMaximo };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetClienteDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ClienteBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, double CreditoMaximo, string Nome, DateTime DtNascimento, string NIF)
        {             
            IClienteDao dao = NHibernateDaoFactory.Current.GetClienteDao();  

            Cliente record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.CreditoMaximo = CreditoMaximo;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ClienteBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Cliente Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetClienteDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ClienteBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Cliente ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ClienteBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetClienteDao().Delete( Read( recordId ) );
        }
    }
}
  