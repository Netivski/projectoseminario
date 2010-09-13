
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class CursoDomain : DomainObject<long>, IEntity
  
  {
    public CursoDomain () {}

    
    IList<Turma> _Turma = new List<Turma>();  
  
    public virtual string Nome { get; set; }
  
    public virtual IList<Turma> Turma {
        get { return new List<Turma>(_Turma).AsReadOnly(); }
        protected set { _Turma = value; }
    }     
  
    public void AddTurma(Turma obj) {
        if (obj != null &&  !_Turma.Contains(obj)) {
            _Turma.Add(obj);
        }
    }

    public void RemoveTurma(Turma obj) {
        if (obj != null &&  _Turma.Contains(obj)) {
            _Turma.Remove(obj);
        }
    }    
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomeCurso, Nome) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Curso obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  