
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
  public abstract class CustomerDomain : DomainObject<long>, IEntity
  {
    public CustomerDomain () {}

    
    IList<LastPassword> _LastPasswords = new List<LastPassword>();  
  
    IList<Contact> _Contacts = new List<Contact>();  
  
    IList<OrderHeader> _Orders = new List<OrderHeader>();  
  
    public virtual string UserName { get; set; }
  
    public virtual string Password { get; set; }
  
    public virtual bool AccountNonExpired { get; set; }
  
    public virtual bool AccountNonLocked { get; set; }
  
    public virtual bool CredentialsNonExpired { get; set; }
  
    public virtual bool Enabled { get; set; }
  
    public virtual bool LastFailedLogin { get; set; }
  
    public virtual int FailedLoginCount { get; set; }
  
    public virtual DateTime LastLoginDate { get; set; }
  
    public virtual DateTime CreateDate { get; set; }
  
    public virtual DateTime BirthDate { get; set; }
  
    public virtual string Hint { get; set; }
  
    public virtual string HintAnswer { get; set; }
  
    public virtual IList<LastPassword> LastPasswords {
        get { return new List<LastPassword>(_LastPasswords).AsReadOnly(); }
        protected set { _LastPasswords = value; }
    }     
  
    public virtual IList<Contact> Contacts {
        get { return new List<Contact>(_Contacts).AsReadOnly(); }
        protected set { _Contacts = value; }
    }     
  
    public virtual IList<OrderHeader> Orders {
        get { return new List<OrderHeader>(_Orders).AsReadOnly(); }
        protected set { _Orders = value; }
    }     
  
    public void AddLastPassword(LastPassword obj) {
        obj.Customer = (Customer)this;
        if (obj != null &&  !_LastPasswords.Contains(obj)) {
            _LastPasswords.Add(obj);
        }
    }

    public void RemoveLastPassword(LastPassword obj) {
        if (obj != null &&  _LastPasswords.Contains(obj)) {
            _LastPasswords.Remove(obj);
        }
    }    
  
    public void AddContact(Contact obj) {
        obj.Customer = (Customer)this;
        if (obj != null &&  !_Contacts.Contains(obj)) {
            _Contacts.Add(obj);
        }
    }

    public void RemoveContact(Contact obj) {
        if (obj != null &&  _Contacts.Contains(obj)) {
            _Contacts.Remove(obj);
        }
    }    
  
    public void AddOrderHeader(OrderHeader obj) {
        obj.Customer = (Customer)this;
        if (obj != null &&  !_Orders.Contains(obj)) {
            _Orders.Add(obj);
        }
    }

    public void RemoveOrderHeader(OrderHeader obj) {
        if (obj != null &&  _Orders.Contains(obj)) {
            _Orders.Remove(obj);
        }
    }    
  

    public virtual bool IsValid
    {
      get
      { 
        
        return Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) && Validator.IsValid(UserTypeMetadata.CustomerPassword, Password) && Validator.IsValid(UserTypeMetadata.CustomerAccountNonExpired, AccountNonExpired) && Validator.IsValid(UserTypeMetadata.CustomerAccountNonLocked, AccountNonLocked) && Validator.IsValid(UserTypeMetadata.CustomerCredentialsNonExpired, CredentialsNonExpired) && Validator.IsValid(UserTypeMetadata.CustomerEnabled, Enabled) && Validator.IsValid(UserTypeMetadata.CustomerLastFailedLogin, LastFailedLogin) && Validator.IsValid(UserTypeMetadata.CustomerFailedLoginCount, FailedLoginCount) && Validator.IsValid(UserTypeMetadata.CustomerLastLoginDate, LastLoginDate) && Validator.IsValid(UserTypeMetadata.CustomerCreateDate, CreateDate) && Validator.IsValid(UserTypeMetadata.CustomerBirthDate, BirthDate) && Validator.IsValid(UserTypeMetadata.CustomerHint, Hint) && Validator.IsValid(UserTypeMetadata.CustomerHintAnswer, HintAnswer) ;
          
      }
    }
    
    public virtual EntityStateException StateException
    {
      get
      {
        if (this.IsValid) return null;
        
        
        EntityStateException ese = new EntityStateException("Customer");
        
        if( !Validator.IsValid(UserTypeMetadata.CustomerUserName, UserName) )
        {
          ese.Add( new GeneralArgumentException<string>( "UserName", "CustomerUserName", UserName) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerPassword, Password) )
        {
          ese.Add( new GeneralArgumentException<string>( "Password", "CustomerPassword", Password) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerAccountNonExpired, AccountNonExpired) )
        {
          ese.Add( new GeneralArgumentException<bool>( "AccountNonExpired", "CustomerAccountNonExpired", AccountNonExpired) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerAccountNonLocked, AccountNonLocked) )
        {
          ese.Add( new GeneralArgumentException<bool>( "AccountNonLocked", "CustomerAccountNonLocked", AccountNonLocked) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerCredentialsNonExpired, CredentialsNonExpired) )
        {
          ese.Add( new GeneralArgumentException<bool>( "CredentialsNonExpired", "CustomerCredentialsNonExpired", CredentialsNonExpired) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerEnabled, Enabled) )
        {
          ese.Add( new GeneralArgumentException<bool>( "Enabled", "CustomerEnabled", Enabled) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerLastFailedLogin, LastFailedLogin) )
        {
          ese.Add( new GeneralArgumentException<bool>( "LastFailedLogin", "CustomerLastFailedLogin", LastFailedLogin) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerFailedLoginCount, FailedLoginCount) )
        {
          ese.Add( new GeneralArgumentException<int>( "FailedLoginCount", "CustomerFailedLoginCount", FailedLoginCount) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerLastLoginDate, LastLoginDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "LastLoginDate", "CustomerLastLoginDate", LastLoginDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerCreateDate, CreateDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "CreateDate", "CustomerCreateDate", CreateDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerBirthDate, BirthDate) )
        {
          ese.Add( new GeneralArgumentException<DateTime>( "BirthDate", "CustomerBirthDate", BirthDate) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerHint, Hint) )
        {
          ese.Add( new GeneralArgumentException<string>( "Hint", "CustomerHint", Hint) );
        }
  
        if( !Validator.IsValid(UserTypeMetadata.CustomerHintAnswer, HintAnswer) )
        {
          ese.Add( new GeneralArgumentException<string>( "HintAnswer", "CustomerHintAnswer", HintAnswer) );
        }
  
    
        return ese;
          
          
      }
    }    

    public override int GetHashCode()
    {
      return string.Format("{0}.{1}", GetType().FullName, ID).GetHashCode();
    }

        
    public bool Equals(Customer obj)
    {
       if(obj == null) return false; 
      return obj.ID == ID;   
    }
  }
}
  