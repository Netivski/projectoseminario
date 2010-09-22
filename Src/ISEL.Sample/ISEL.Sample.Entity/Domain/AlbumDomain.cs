
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
  public abstract class AlbumDomain : DomainObject<long>, IEntity
  {
    public AlbumDomain () {}

    
    IList<LojaAlbum> _Lojas = new List<LojaAlbum>();  
  
    IList<DirectorAlbum> _Director = new List<DirectorAlbum>();  
  
    public virtual string Titulo { get; set; }
  
    public virtual IList<LojaAlbum> Lojas {
        get { return new List<LojaAlbum>(_Lojas).AsReadOnly(); }
        protected set { _Lojas = value; }
    }     
  
    public virtual IList<DirectorAlbum> Director {
        get { return new List<DirectorAlbum>(_Director).AsReadOnly(); }
        protected set { _Director = value; }
    }     
  
    public virtual Editor Editor { get; set; }
  
    public void AddLojaAlbum(LojaAlbum obj) {
        if (obj != null &&  !_Lojas.Contains(obj)) {
            _Lojas.Add(obj);
        }
    }

    public void RemoveLojaAlbum(LojaAlbum obj) {
        if (obj != null &&  _Lojas.Contains(obj)) {
            _Lojas.Remove(obj);
        }
    }    
  
    public void AddDirectorAlbum(DirectorAlbum obj) {
        if (obj != null &&  !_Director.Contains(obj)) {
            _Director.Add(obj);
        }
    }

    public void RemoveDirectorAlbum(DirectorAlbum obj) {
        if (obj != null &&  _Director.Contains(obj)) {
            _Director.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.tituloAlbum, Titulo) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Album");
        
        if( !Validator.IsValid(UserTypeMetadata.tituloAlbum, Titulo) )
        {
          ese.Add( new GeneralArgumentException<string>( "Titulo", "tituloAlbum", Titulo) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Album obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  