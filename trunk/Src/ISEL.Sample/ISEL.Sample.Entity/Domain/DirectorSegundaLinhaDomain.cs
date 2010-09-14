
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
  public  class DirectorSegundaLinhaDomain : Director
  {
    public DirectorSegundaLinhaDomain () {}

    
    public virtual int Antiguidade { get; set; }
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.antiguidadeDirectorSegundaLinha, Antiguidade) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("DirectorSegundaLinha");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.antiguidadeDirectorSegundaLinha, Antiguidade) )
        {
          ese.Add( new GeneralArgumentException<int>( "Antiguidade", "antiguidadeDirectorSegundaLinha", Antiguidade) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(DirectorSegundaLinha obj)
    {
       return base.Equals((Director)obj);   
    }
  }
}
  