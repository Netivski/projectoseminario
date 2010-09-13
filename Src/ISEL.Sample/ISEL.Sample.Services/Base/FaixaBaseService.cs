
using System;    
using System.Security.Permissions;
using System.Security;
using EDM.FoundationClasses.Security.Permissions;
using ISEL.Sample.Entity;
using ISEL.Sample.Entity.DataInterfaces;
using ISEL.Sample.Entity.Data;

namespace ISEL.Sample.Services.Base
{
    public class FaixaBaseService
    {   
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaixaBaseService", MethodName="Create", Unrestricted = false)] 
        public virtual long Create(string Nome, string Duracao, string Genero)
        {
            Faixa record = new Faixa(){ Nome = Nome, Duracao = Duracao, Genero = Genero };            
    
            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            NHibernateDaoFactory.Current.GetFaixaDao().Save(record);

            return record.ID;
        }
        
        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaixaBaseService", MethodName="Update", Unrestricted = false)] 
        public virtual void Update(long recordId, string Nome, string Duracao, string Genero)
        {             
            IFaixaDao dao = NHibernateDaoFactory.Current.GetFaixaDao();  

            Faixa record = dao.GetById(recordId, false);
            record.Nome = Nome;
            record.Duracao = Duracao;
            record.Genero = Genero;            

            if (!record.IsValid())
            {
                //throw new ArgumentException
            }

            dao.SaveOrUpdate(record);                                                         
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaixaBaseService", MethodName="Read", Unrestricted = false)] 
        public virtual Faixa Read(long recordId)
        {
            return NHibernateDaoFactory.Current.GetFaixaDao().GetById(recordId, false);
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaixaBaseService", MethodName="ReadByUnique", Unrestricted = false)] 
        public virtual Faixa ReadByUnique()
        {
            return null;
        }

        
        [RuntimeSecurity(SecurityAction.Demand, ClassName="FaixaBaseService", MethodName="Delete", Unrestricted = false)] 
        public virtual void Delete(long recordId)
        {
            NHibernateDaoFactory.Current.GetFaixaDao().Delete( Read( recordId ) );
        }
    }
}
  