
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
    public class DirectorPrimeiraLinhaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorPrimeiraLinhaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string NomeDepartamento, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            DirectorPrimeiraLinha record = new DirectorPrimeiraLinha(){ NomeDepartamento = NomeDepartamento, LimiteCartaoCredito = LimiteCartaoCredito, LimiteAprovacao = LimiteAprovacao, Numero = Numero, DtAdmissao = DtAdmissao, Nome = Nome, DtNascimento = DtNascimento, NIF = NIF };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetDirectorPrimeiraLinhaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorPrimeiraLinhaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string NomeDepartamento, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IDirectorPrimeiraLinhaDao dao = NHibernateDaoFactory.Current.GetDirectorPrimeiraLinhaDao();  

            DirectorPrimeiraLinha record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;
            record.LimiteCartaoCredito = LimiteCartaoCredito;
            record.LimiteAprovacao = LimiteAprovacao;
            record.NomeDepartamento = NomeDepartamento;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorPrimeiraLinhaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual DirectorPrimeiraLinha Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDirectorPrimeiraLinhaDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorPrimeiraLinhaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual DirectorPrimeiraLinha ReadByUnique(string NIF)
        {
            DirectorPrimeiraLinha record = new DirectorPrimeiraLinha();
            
            if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
            {
              throw new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF);
            }                    
  
            record.NIF = NIF; 
  

            return NHibernateDaoFactory.Current.GetDirectorPrimeiraLinhaDao().GetUniqueByExample(record, "NomeDepartamento", "LimiteCartaoCredito", "LimiteAprovacao", "Numero", "DtAdmissao", "Nome", "DtNascimento" );
        }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorPrimeiraLinhaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDirectorPrimeiraLinhaDao().Delete( Read( recordId ) );
        }
    }
}
  