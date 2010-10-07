
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using EDM.FoundationClasses.Exception;
using EDM.FoundationClasses.Exception.FoundationType;
using FutureView.ECom.Rtti;
using System.Collections.Generic;

namespace FutureView.ECom.Entity.Domain
{
  [Serializable]
  public  class CategoryDomain : DomainObject<long>, IEntity
  {
    public CategoryDomain () {}

    
    IList<CategorySku> _CategorySku = new List<CategorySku>();  
  
    public virtual string Name { get; set; }
  
    public virtual string Description { get; set; }
  
    public virtual string SmallImagePath { get; set; }
  
    public virtual string LargeImagePath { get; set; }
  
    public virtual DateTime EffectiveStartDate { get; set; }
  
    public virtual DateTime EffectiveEndDate { get; set; }
  
    public virtual IList<CategorySku> CategorySku {
        get { return new List<CategorySku>(_CategorySku).AsReadOnly(); }
        protected set { _CategorySku = value; }
    }     
  
    public void AddCategorySku(CategorySku obj) {
        obj.Category = (Category)this;
        if (obj != null &&  !_CategorySku.Contains(obj)) {
            _CategorySku.Add(obj);
        }
    }

    public void RemoveCategorySku(CategorySku obj) {
        if (obj != null &&  _CategorySku.Contains(obj)) {
            _CategorySku.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.CategoryName, Name) && Validator.IsValid(UserTypeMetadata.CategoryDescription, Description) && Validator.IsValid(UserTypeMetadata.CategorySmallImagePath, SmallImagePath) && Validator.IsValid(UserTypeMetadata.CategoryLargeImagePath, LargeImagePath) && Validator.IsValid(UserTypeMetadata.CategoryEffectiveStartDate, EffectiveStartDate) && Validator.IsValid(UserTypeMetadata.CategoryEffectiveEndDate, EffectiveEndDate) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Category");
        
        if( !Validator.IsValid(UserTypeMetadata.CategoryName, Name) )
        {
          ese.Add( new GeneralArgumentException<string>( "Name", "CategoryName", Name) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CategoryDescription, Description) )
        {
          ese.Add( new GeneralArgumentException<string>( "Description", "CategoryDescription", Description) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CategorySmallImagePath, SmallImagePath) )
        {
          ese.Add( new GeneralArgumentException<string>( "SmallImagePath", "CategorySmallImagePath", SmallImagePath) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CategoryLargeImagePath, LargeImagePath) )
        {
          ese.Add( new GeneralArgumentException<string>( "LargeImagePath", "CategoryLargeImagePath", LargeImagePath) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CategoryEffectiveStartDate, EffectiveStartDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "EffectiveStartDate", "CategoryEffectiveStartDate", EffectiveStartDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CategoryEffectiveEndDate, EffectiveEndDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "EffectiveEndDate", "CategoryEffectiveEndDate", EffectiveEndDate) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Category obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  