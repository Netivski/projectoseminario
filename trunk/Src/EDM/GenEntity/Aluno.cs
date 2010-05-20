using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using GenRtti;

namespace GenEntity
{
    [Serializable]
    public class Aluno: Pessoa
    {
        public Aluno() { }

        public virtual int num { get; set; }

        public override bool IsValid()
        {
            return base.IsValid() && Validator<int>.IsValid(UserTypeMetadata.uInt, id);
        }

        // Tem que ser rescrito o método GetHashCode, caso implemente fields unique

        public bool Equals(Aluno obj)
        {
            if (obj == null) return false;

            //Utilizar todos os fields que sejam unique
            return base.Equals((Pessoa)obj); 
        }


    }
}
