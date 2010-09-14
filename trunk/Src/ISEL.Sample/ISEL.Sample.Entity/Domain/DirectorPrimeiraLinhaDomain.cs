
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
  public  class DirectorPrimeiraLinhaDomain : Director
  {
    public DirectorPrimeiraLinhaDomain () {}

    
    public virtual string NomeDepartamento { get; set; }
  

    public override bool IsValid
    {
      get
      {
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.nomeDepartamentoDirectorPrimeiraLinha, NomeDepartamento) ;
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("DirectorPrimeiraLinha");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.nomeDepartamentoDirectorPrimeiraLinha, NomeDepartamento) )
        {
          ese.Add( new GeneralArgumentException<string>( "NomeDepartamento", "nomeDepartamentoDirectorPrimeiraLinha", NomeDepartamento) );
        }
  
    
        return ese;
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(DirectorPrimeiraLinha obj)
    {
       return base.Equals((Director)obj);   
    }
  }
}
  