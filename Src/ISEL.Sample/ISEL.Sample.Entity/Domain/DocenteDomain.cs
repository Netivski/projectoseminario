﻿
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
  public  class DocenteDomain : DomainObject<long>, IEntity
  {
    public DocenteDomain () {}

    
    IList<Calendario> _Lecciona = new List<Calendario>();  
  
    public virtual string Nome { get; set; }
  
    public virtual int Numero { get; set; }
  
    public virtual IList<Calendario> Lecciona {
        get { return new List<Calendario>(_Lecciona).AsReadOnly(); }
        protected set { _Lecciona = value; }
    }     
  
    public void AddCalendario(Calendario obj) {
        if (obj != null &&  !_Lecciona.Contains(obj)) {
            _Lecciona.Add(obj);
        }
    }

    public void RemoveCalendario(Calendario obj) {
        if (obj != null &&  _Lecciona.Contains(obj)) {
            _Lecciona.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.nomeDocente, Nome) && Validator.IsValid(UserTypeMetadata.numeroDocente, Numero) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Docente");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeDocente, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeDocente", Nome) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.numeroDocente, Numero) )
        {
          ese.Add( new GeneralArgumentException<int>( "Numero", "numeroDocente", Numero) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Docente obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  