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
  public  class EditorDomain : DomainObject<long>, IEntity
  {
    public EditorDomain () {}

    
    IList<Album> _Albuns = new List<Album>();  
  
    public virtual string Nome { get; set; }
  
    public virtual string Pais { get; set; }
  
    public virtual IList<Album> Albuns {
        get { return new List<Album>(_Albuns).AsReadOnly(); }
        protected set { _Albuns = value; }
    }     
  
    public void AddAlbum(Album obj) {
        if (obj != null &&  !_Albuns.Contains(obj)) {
            _Albuns.Add(obj);
        }
    }

    public void RemoveAlbum(Album obj) {
        if (obj != null &&  _Albuns.Contains(obj)) {
            _Albuns.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.nomeEditor, Nome) && Validator.IsValid(UserTypeMetadata.pais, Pais) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Editor");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeEditor, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeEditor", Nome) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.pais, Pais) )
        {
          ese.Add( new GeneralArgumentException<string>( "Pais", "pais", Pais) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Editor obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  