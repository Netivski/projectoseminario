
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
  public abstract class DirectorDomain : Empregado
  {
    public DirectorDomain () {}

    
    public virtual double LimiteCartaoCredito { get; set; }
  
    public virtual double LimiteAprovacao { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.limiteCartaoCreditoDirector, LimiteCartaoCredito) && Validator.IsValid(UserTypeMetadata.limiteAprovacaoDirector, LimiteAprovacao) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Director");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.limiteCartaoCreditoDirector, LimiteCartaoCredito) )
        {
          ese.Add( new GeneralArgumentException<double>( "LimiteCartaoCredito", "limiteCartaoCreditoDirector", LimiteCartaoCredito) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.limiteAprovacaoDirector, LimiteAprovacao) )
        {
          ese.Add( new GeneralArgumentException<double>( "LimiteAprovacao", "limiteAprovacaoDirector", LimiteAprovacao) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Director obj)
    {
       return base.Equals((Empregado)obj);   
    }
  }
}
  