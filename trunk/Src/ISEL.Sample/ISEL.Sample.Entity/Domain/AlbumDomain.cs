
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

    
    public virtual string Titulo { get; set; }
  
    public virtual Editor Editor { get; set; }
  

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
  