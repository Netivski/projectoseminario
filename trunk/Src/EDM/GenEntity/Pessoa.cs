using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using GenRtti;

namespace GenEntity
{
    [Serializable]
    public abstract class Pessoa: IEntity
    {
        public Pessoa() { }

        public virtual int id { get; set; }
        public virtual string nome { get; set; }
        public virtual DateTime dtNascimento { get; set; }

        public virtual bool IsValid()
        {
            // Utilizar operador && para todos os fields unique

            return Validator.IsValid(UserTypeMetadata.uInt, id);
        }

        public override int GetHashCode()
        {
            // Implementado com todos os fields que sejam unique, utilizando o operador ^ 
            return id.GetHashCode();
        }

        public bool Equals(Pessoa obj)
        {
            if (obj == null) return false;

            //Na comparação utilizar todos os fields que sejam unique
            return id == obj.id;
        }
    }
}
