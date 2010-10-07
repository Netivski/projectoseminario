using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using FutureView.ECom.Rtti;

namespace FutureView.ECom.Entity
{
    [Serializable]
    public abstract class Customer : Domain.CustomerDomain
    {
        public Customer() { }
        
        public Contact GetContactByType(Type contactType)
        {
            foreach (Contact contact in this.Contacts) if (contact.GetType() == contactType) return contact;

            return null;
        }
    }
}
