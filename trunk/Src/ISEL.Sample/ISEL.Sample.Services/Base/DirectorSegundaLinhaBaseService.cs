
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
    public class DirectorSegundaLinhaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(int Antiguidade, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            DirectorSegundaLinha record = new DirectorSegundaLinha(){ Antiguidade = Antiguidade, LimiteCartaoCredito = LimiteCartaoCredito, LimiteAprovacao = LimiteAprovacao, Numero = Numero, DtAdmissao = DtAdmissao, Nome = Nome, DtNascimento = DtNascimento, NIF = NIF };            
    
            if (!record.IsValid) throw record.StateException;

            NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, int Antiguidade, double LimiteCartaoCredito, double LimiteAprovacao, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IDirectorSegundaLinhaDao dao = NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao();  

            DirectorSegundaLinha record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;
            record.LimiteCartaoCredito = LimiteCartaoCredito;
            record.LimiteAprovacao = LimiteAprovacao;
            record.Antiguidade = Antiguidade;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual DirectorSegundaLinha Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual DirectorSegundaLinha ReadByUnique(string NIF)
        {
            DirectorSegundaLinha record = new DirectorSegundaLinha();
            
            if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
            {
              throw new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF);
            }                    
  
            record.NIF = NIF; 
  

            return NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().GetUniqueByExample(record, "Antiguidade", "LimiteCartaoCredito", "LimiteAprovacao", "Numero", "DtAdmissao", "Nome", "DtNascimento" );
        }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().Delete( Read( recordId ) );
        }
    }
}
  