using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace EDM.FoundationClasses.Exception
{
    public class EntityStateException : ArgumentException
    {
        ICollection<ArgumentException> exceptionBag = new LinkedList<ArgumentException>();

        public EntityStateException(string name) { Name = name; }

        public string Name { get; protected set; }

        public override string Message
        {
            get
            {
                StringBuilder rValue = new StringBuilder();
                IEnumerator<ArgumentException>  bagEnum = exceptionBag.GetEnumerator( );
                while (bagEnum.MoveNext()) rValue.AppendLine(bagEnum.Current.Message); 

                return rValue.ToString();
            }
        }

        public void Add(ArgumentException exc) { exceptionBag.Add(exc); } 
    }
}
