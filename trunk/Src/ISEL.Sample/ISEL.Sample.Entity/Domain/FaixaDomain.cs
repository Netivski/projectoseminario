
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class FaixaDomain : DomainObject<long>, IEntity
  
  {
    public FaixaDomain () {}

    
    public virtual string Nome { get; set; }
  
    public virtual string Duracao { get; set; }
  
    public virtual string Genero { get; set; }
  
    public virtual LP LP { get; set; }
  
    public virtual EP EP { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomeMusica, Nome) && Validator.IsValid(UserTypeMetadata.tempoMusica, Duracao) && Validator.IsValid(UserTypeMetadata.generoMusical, Genero) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Faixa obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  