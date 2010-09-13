
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class PostDomain : DomainObject<long>, IEntity
  
  {
    public PostDomain () {}

    
    IList<Comment> _Comments = new List<Comment>();  
  
    public virtual string Name { get; set; }
  
    public virtual DateTime Create { get; set; }
  
    public virtual IList<Comment> Comments {
        get { return new List<Comment>(_Comments).AsReadOnly(); }
        protected set { _Comments = value; }
    }     
  
    public void AddComment(Comment obj) {
        if (obj != null &&  !_Comments.Contains(obj)) {
            _Comments.Add(obj);
        }
    }

    public void RemoveComment(Comment obj) {
        if (obj != null &&  _Comments.Contains(obj)) {
            _Comments.Remove(obj);
        }
    }    
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.namePost, Name) && Validator.IsValid(UserTypeMetadata.createPost, Create) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Post obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  