
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
  public  class ManagerDomain : Empregado
  {
    public ManagerDomain () {}

    
    public virtual int LitrosCombustivel { get; set; }
  

    public override bool IsValid
    {
      get
      {
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.litrosCombustivelManager, LitrosCombustivel) ;
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Manager");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.litrosCombustivelManager, LitrosCombustivel) )
        {
          ese.Add( new GeneralArgumentException<int>( "LitrosCombustivel", "litrosCombustivelManager", LitrosCombustivel) );
        }
  
    
        return ese;
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Manager obj)
    {
       return base.Equals((Empregado)obj);   
    }
  }
}
  