
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class PessoaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PessoaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, DateTime DtNascimento, string NIF)
        {
            Pessoa record = new Pessoa(){ Nome = Nome, DtNascimento = DtNascimento, NIF = NIF };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetPessoaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PessoaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, DateTime DtNascimento, string NIF)
        {             
            IPessoaDao dao = NHibernateDaoFactory.Current.GetPessoaDao();  

            Pessoa record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PessoaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Pessoa Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetPessoaDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PessoaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Pessoa ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="PessoaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetPessoaDao().Delete( Read( recordId ) );
        }
    }
}
  