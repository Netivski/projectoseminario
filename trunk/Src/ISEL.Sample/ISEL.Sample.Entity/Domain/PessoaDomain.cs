
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public abstract class PessoaDomain : DomainObject<long>, IEntity
  
  {
    public PessoaDomain () {}

    
    public virtual string Nome { get; set; }
  
    public virtual DateTime DtNascimento { get; set; }
  
    public virtual string NIF { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomePessoa, Nome) && Validator.IsValid(UserTypeMetadata.dtNascimentoPessoa, DtNascimento) && Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Pessoa obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  