
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
    public class DirectorBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Director record = new Director(){ Nome = Nome, DtNascimento = DtNascimento, NIF = NIF, Numero = Numero, DtAdmissao = DtAdmissao, LimiteCartaoCredito = LimiteCartaoCredito, LimiteAprovacao = LimiteAprovacao };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetDirectorDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IDirectorDao dao = NHibernateDaoFactory.Current.GetDirectorDao();  

            Director record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;
            record.LimiteCartaoCredito = LimiteCartaoCredito;
            record.LimiteAprovacao = LimiteAprovacao;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Director Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDirectorDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Director ReadByUnique(string NIF)
        {
            Director record = new Director();
            
            if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
            {
              throw new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF);
            }                    
  
            record.NIF = NIF; 
  

            return NHibernateDaoFactory.Current.GetDirectorDao().GetUniqueByExample(record, "LimiteCartaoCredito", "LimiteAprovacao", "Numero", "DtAdmissao", "Nome", "DtNascimento" );
        }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDirectorDao().Delete( Read( recordId ) );
        }
    }
}
  