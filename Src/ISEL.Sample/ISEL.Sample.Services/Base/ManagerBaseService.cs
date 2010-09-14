
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
    public class ManagerBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ManagerBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(int LitrosCombustivel, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Manager record = new Manager(){ LitrosCombustivel = LitrosCombustivel, Numero = Numero, DtAdmissao = DtAdmissao, Nome = Nome, DtNascimento = DtNascimento, NIF = NIF };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetManagerDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ManagerBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, int LitrosCombustivel, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IManagerDao dao = NHibernateDaoFactory.Current.GetManagerDao();  

            Manager record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;
            record.LitrosCombustivel = LitrosCombustivel;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ManagerBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Manager Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetManagerDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ManagerBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Manager ReadByUnique(string NIF)
        {
            Manager record = new Manager();
            
            if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
            {
              throw new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF);
            }                    
  
            record.NIF = NIF; 
  

            return NHibernateDaoFactory.Current.GetManagerDao().GetUniqueByExample(record, "LitrosCombustivel", "Numero", "DtAdmissao", "Nome", "DtNascimento" );
        }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="ManagerBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetManagerDao().Delete( Read( recordId ) );
        }
    }
}
  