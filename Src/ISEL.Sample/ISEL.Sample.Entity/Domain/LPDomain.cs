
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
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
  

    public override bool IsValid()
    {
      return  base.IsValid() && Validator.IsValid(UserTypeMetadata.dataEdicaoLP, DtEdicao) ;
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
  