
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
  public  class ClienteDomain : Pessoa
  {
    public ClienteDomain () {}

    
    public virtual double CreditoMaximo { get; set; }
  

    public override bool IsValid
    {
      get
      {
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.creditoMaximoCliente, CreditoMaximo) ;
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        EntityStateException ese = new EntityStateException("Cliente");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.creditoMaximoCliente, CreditoMaximo) )
        {
          ese.Add( new GeneralArgumentException<double>( "CreditoMaximo", "creditoMaximoCliente", CreditoMaximo) );
        }
  
    
        return ese;
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Cliente obj)
    {
       return base.Equals((Pessoa)obj);   
    }
  }
}
  