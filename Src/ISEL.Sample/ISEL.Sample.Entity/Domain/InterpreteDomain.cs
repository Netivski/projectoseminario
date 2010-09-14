
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
  public  class InterpreteDomain : DomainObject<long>, IEntity
  {
    public InterpreteDomain () {}

    
    IList<Album> _Albuns = new List<Album>();  
  
    public virtual string Nome { get; set; }
  
    public virtual string Nacionalidade { get; set; }
  
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
        
        return Validator.IsValid(UserTypeMetadata.nomeArtista, Nome) && Validator.IsValid(UserTypeMetadata.pais, Nacionalidade) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Interprete");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeArtista, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeArtista", Nome) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.pais, Nacionalidade) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nacionalidade", "pais", Nacionalidade) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Interprete obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  