
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class EPDomain : Album
  {
    public EPDomain () {}

    
    IList<Faixa> _Faixas = new List<Faixa>();  
  
    public virtual DateTime DtLancamento { get; set; }
  
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
      return  base.IsValid() && Validator.IsValid(UserTypeMetadata.dataEdicaoLP, DtLancamento) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(EP obj)
    {
       return base.Equals((Album)obj);   
    }
  }
}
  