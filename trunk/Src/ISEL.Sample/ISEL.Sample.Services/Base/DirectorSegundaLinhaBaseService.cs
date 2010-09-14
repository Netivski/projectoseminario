﻿
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class DirectorSegundaLinhaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(int Antiguidade, double LimiteCartaoCredito, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {
            DirectorSegundaLinha record = new DirectorSegundaLinha(){ Nome = Nome, DtNascimento = DtNascimento, NIF = NIF, Numero = Numero, DtAdmissao = DtAdmissao, LimiteCartaoCredito = LimiteCartaoCredito, Antiguidade = Antiguidade };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, int Antiguidade, double LimiteCartaoCredito, int Numero, DateTime DtAdmissao, string Nome, DateTime DtNascimento, string NIF)
        {             
            IDirectorSegundaLinhaDao dao = NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao();  

            DirectorSegundaLinha record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.DtNascimento = DtNascimento;
            record.NIF = NIF;
            record.Numero = Numero;
            record.DtAdmissao = DtAdmissao;
            record.LimiteCartaoCredito = LimiteCartaoCredito;
            record.Antiguidade = Antiguidade;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual DirectorSegundaLinha Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual DirectorSegundaLinha ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="DirectorSegundaLinhaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetDirectorSegundaLinhaDao().Delete( Read( recordId ) );
        }
    }
}
  