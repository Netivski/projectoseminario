
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
  public  class FaixaDomain : DomainObject<long>, IEntity
  {
    public FaixaDomain () {}

    
    public virtual string Nome { get; set; }
  
    public virtual string Duracao { get; set; }
  
    public virtual string Genero { get; set; }
  
    public virtual LP LP { get; set; }
  
    public virtual EP EP { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.nomeMusica, Nome) && Validator.IsValid(UserTypeMetadata.tempoMusica, Duracao) && Validator.IsValid(UserTypeMetadata.generoMusical, Genero) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Faixa");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeMusica, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeMusica", Nome) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.tempoMusica, Duracao) )
        {
          ese.Add( new GeneralArgumentException<string>( "Duracao", "tempoMusica", Duracao) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.generoMusical, Genero) )
        {
          ese.Add( new GeneralArgumentException<string>( "Genero", "generoMusical", Genero) );
        }
  
    
        return ese;
          
          
      }
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
  