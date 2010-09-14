
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class EmpregadoDomain : Pessoa
  {
    public EmpregadoDomain () {}

    
    public virtual int Numero { get; set; }
  
    public virtual DateTime DtAdmissao { get; set; }
  

    public override bool IsValid()
    {
      return  base.IsValid() && Validator.IsValid(UserTypeMetadata.numeroEmpregado, Numero) && Validator.IsValid(UserTypeMetadata.dtAdmissaoEmpregado, DtAdmissao) ;
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
  