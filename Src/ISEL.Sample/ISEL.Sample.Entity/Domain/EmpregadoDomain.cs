
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
  public abstract class EmpregadoDomain : Pessoa
  {
    public EmpregadoDomain () {}

    
    public virtual int Numero { get; set; }
  
    public virtual DateTime DtAdmissao { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.numeroEmpregado, Numero) && Validator.IsValid(UserTypeMetadata.dtAdmissaoEmpregado, DtAdmissao) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Empregado");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.numeroEmpregado, Numero) )
        {
          ese.Add( new GeneralArgumentException<int>( "Numero", "numeroEmpregado", Numero) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.dtAdmissaoEmpregado, DtAdmissao) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DtAdmissao", "dtAdmissaoEmpregado", DtAdmissao) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Empregado obj)
    {
       return base.Equals((Pessoa)obj);   
    }
  }
}
  