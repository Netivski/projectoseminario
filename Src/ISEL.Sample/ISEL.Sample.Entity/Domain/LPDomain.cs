
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
  public  class LPDomain : Album
  {
    public LPDomain () {}

    
    IList<Faixa> _Faixas = new List<Faixa>();  
  
    public virtual DateTime DtEdicao { get; set; }
  
    public virtual IList<Faixa> Faixas {
        get { return new List<Faixa>(_Faixas).AsReadOnly(); }
        protected set { _Faixas = value; }
    }     
  
    public void AddFaixa(Faixa obj) {
        if (obj != null &&  !_Faixas.Contains(obj)) {
            _Faixas.Add(obj);
        }
    }

    public void RemoveFaixa(Faixa obj) {
        if (obj != null &&  _Faixas.Contains(obj)) {
            _Faixas.Remove(obj);
        }
    }    
  

    public override bool IsValid
    {
      get
      { 
        
        return  base.IsValid && Validator.IsValid(UserTypeMetadata.dataEdicaoLP, DtEdicao) ;
          
      }
    }
    
    public override EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("LP");
        
            ese.Add(base.StateException);  
        
        if( !Validator.IsValid(UserTypeMetadata.dataEdicaoLP, DtEdicao) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "DtEdicao", "dataEdicaoLP", DtEdicao) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(LP obj)
    {
       return base.Equals((Album)obj);   
    }
  }
}
  