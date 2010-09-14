
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
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
  

    public virtual bool IsValid
    {
      get
      {
        return Validator.IsValid(UserTypeMetadata.nomePessoa, Nome) && Validator.IsValid(UserTypeMetadata.dtNascimentoPessoa, DtNascimento) && Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) ;
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Pessoa");
        
        if( !Validator.IsValid(UserTypeMetadata.nomePessoa, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomePessoa", Nome) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.dtNascimentoPessoa, DtNascimento) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DtNascimento", "dtNascimentoPessoa", DtNascimento) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.nifPessoa, NIF) )
        {
          ese.Add( new GeneralArgumentException<string>( "NIF", "nifPessoa", NIF) );
        }
  
    
        return ese;
      }
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
  