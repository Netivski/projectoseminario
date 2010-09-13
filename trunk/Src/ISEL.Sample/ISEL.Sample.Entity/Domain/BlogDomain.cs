
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;
using System.Collections.Generic;

namespace ISEL.Sample.Entity.Domain
{
  [Serializable]
  public  class BlogDomain : DomainObject<long>, IEntity
  
  {
    public BlogDomain () {}

    
    IList<Post> _Posts = new List<Post>();  
  
    public virtual string Nome { get; set; }
  
    public virtual IList<Post> Posts {
        get { return new List<Post>(_Posts).AsReadOnly(); }
        protected set { _Posts = value; }
    }     
  
    public virtual Person Owner { get; set; }
  
    public void AddPost(Post obj) {
        if (obj != null &&  !_Posts.Contains(obj)) {
            _Posts.Add(obj);
        }
    }

    public void RemovePost(Post obj) {
        if (obj != null &&  _Posts.Contains(obj)) {
            _Posts.Remove(obj);
        }
    }    
  

    public virtual bool IsValid()
    {
      return Validator.IsValid(UserTypeMetadata.nomeBlog, Nome) ;
    }

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Blog obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  