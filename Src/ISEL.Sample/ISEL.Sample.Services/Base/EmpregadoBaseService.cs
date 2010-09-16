﻿
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
    public class EmpregadoBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmpregadoBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            Empregado record = new Empregado(){ Numero = Numero, DtAdmissao = DtAdmissao, Nome = Nome, DtNascimento = DtNascimento, NIF = NIF };            
    
            if (!record.IsValid) throw record.StateException;

            DaoFactory.Current.GetEmpregadoDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmpregadoBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IEmpregadoDao dao = DaoFactory.Current.GetEmpregadoDao();  

            Empregado record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;            

            if (!record.IsValid) throw record.StateException;

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmpregadoBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Empregado Read(long recordId)
        {
            return DaoFactory.Current.GetEmpregadoDao().GetById(recordId, false);
        }

         
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmpregadoBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Empregado ReadByUnique(string NIF)
        {
            Empregado record = new Empregado();
            
            if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
            {
              throw new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF);
            }                    
  
            record.NIF = NIF; 
  

            return DaoFactory.Current.GetEmpregadoDao().GetUniqueByExample(record, "Numero", "DtAdmissao", "Nome", "DtNascimento" );
        }
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="EmpregadoBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            DaoFactory.Current.GetEmpregadoDao().Delete( Read( recordId ) );
        }
    }
}
  