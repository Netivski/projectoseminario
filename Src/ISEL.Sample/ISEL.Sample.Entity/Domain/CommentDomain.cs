
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class CommentDomain : DomainObject<long>, IEntity
  
  {
    public CommentDomain () {}

    
    public virtual string Content { get; set; }
  
    public virtual DateTime Create { get; set; }
  
    public virtual Post Post { get; set; }
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.contentComment, Content) && Validator.IsValid(UserTypeMetadata.createComment, Create) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Comment obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  