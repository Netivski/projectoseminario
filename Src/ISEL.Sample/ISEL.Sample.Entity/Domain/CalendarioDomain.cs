
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
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.horaInicioCalendario, HoraInicio) && Validator.IsValid(UserTypeMetadata.horaFimCalendario, HoraFim) && Validator.IsValid(UserTypeMetadata.salaCalendario, Sala) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Calendario");
        
        if( !Validator.IsValid(UserTypeMetadata.horaInicioCalendario, HoraInicio) )
        {
          ese.Add( new GeneralArgumentException<string>( "HoraInicio", "horaInicioCalendario", HoraInicio) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.horaFimCalendario, HoraFim) )
        {
          ese.Add( new GeneralArgumentException<string>( "HoraFim", "horaFimCalendario", HoraFim) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.salaCalendario, Sala) )
        {
          ese.Add( new GeneralArgumentException<string>( "Sala", "salaCalendario", Sala) );
        }
  
    
        return ese;
          
          
      }
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
  