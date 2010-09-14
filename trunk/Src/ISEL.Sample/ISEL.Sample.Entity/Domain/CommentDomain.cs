
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
  public  class CommentDomain : DomainObject<long>, IEntity
  {
    public CommentDomain () {}

    
    public virtual string Content { get; set; }
  
    public virtual DateTime Create { get; set; }
  
    public virtual Post Post { get; set; }
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.contentComment, Content) && Validator.IsValid(UserTypeMetadata.createComment, Create) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Comment");
        
        if( !Validator.IsValid(UserTypeMetadata.contentComment, Content) )
        {
          ese.Add( new GeneralArgumentException<string>( "Content", "contentComment", Content) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.createComment, Create) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "Create", "createComment", Create) );
        }
  
    
        return ese;
          
          
      }
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
  