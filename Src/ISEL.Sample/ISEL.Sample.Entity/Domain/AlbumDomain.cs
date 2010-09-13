
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
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
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.tituloAlbum, Titulo) ;
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
  