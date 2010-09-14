
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
  public  class LojaDomain : DomainObject<long>, IEntity
  {
    public LojaDomain () {}

    
    IList<LojaAlbum> _Albuns = new List<LojaAlbum>();  
  
    public virtual string Nome { get; set; }
  
    public virtual IList<LojaAlbum> Albuns {
        get { return new List<LojaAlbum>(_Albuns).AsReadOnly(); }
        protected set { _Albuns = value; }
    }     
  
    public void AddLojaAlbum(LojaAlbum obj) {
        if (obj != null &&  !_Albuns.Contains(obj)) {
            _Albuns.Add(obj);
        }
    }

    public void RemoveLojaAlbum(LojaAlbum obj) {
        if (obj != null &&  _Albuns.Contains(obj)) {
            _Albuns.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.nomeLoja, Nome) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Loja");
        
        if( !Validator.IsValid(UserTypeMetadata.nomeLoja, Nome) )
        {
          ese.Add( new GeneralArgumentException<string>( "Nome", "nomeLoja", Nome) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Loja obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  