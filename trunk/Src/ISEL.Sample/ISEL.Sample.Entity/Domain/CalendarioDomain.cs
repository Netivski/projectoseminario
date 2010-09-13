
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class CalendarioDomain : DomainObject<long>, IEntity
  
  {
    public CalendarioDomain () {}

    
    public virtual string HoraInicio { get; set; }
  
    public virtual string HoraFim { get; set; }
  
    public virtual string Sala { get; set; }
  
    public virtual Docente Docente { get; set; }
  
    public virtual Ano Ano { get; set; }
  
    public virtual Disciplina Disciplina { get; set; }
  
    public virtual Turma Turma { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.horaInicioCalendario, HoraInicio) && Validator.IsValid(UserTypeMetadata.horaFimCalendario, HoraFim) && Validator.IsValid(UserTypeMetadata.salaCalendario, Sala) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Calendario obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  