using System;
using System.Data;

namespace EDM.FoundationClasses.FoundationType
{
    public class BaseType: IBaseType
    {
        public static IBaseType UString     = new BaseType(typeof(string), null, null, null);
        public static IBaseType UShort      = new BaseType(typeof(short), null, null, null);
        public static IBaseType UInt        = new BaseType(typeof(int), null, null, null);
        public static IBaseType ULong       = new BaseType(typeof(long), null, null, null);
        public static IBaseType UDecimal    = new BaseType(typeof(decimal), null, null, null);
        public static IBaseType UDouble     = new BaseType(typeof(double), null, null, null);
        public static IBaseType UGuid       = new BaseType(typeof(Guid), null, null, null);
        public static IBaseType UDateTime   = new BaseType(typeof(DateTime), null, null, null);
        public static IBaseType UFloat      = new BaseType(typeof(float), null, null, null);

        public static IBaseType SQLGuid     = new BaseType(typeof(Guid), 16, null, null);
        public static IBaseType SQLDateTime = new BaseType(typeof(DateTime), 8, 23, 3);
        public static IBaseType SQLInt      = new BaseType(typeof(int), 4, 10, 0);
        public static IBaseType SQLLong     = new BaseType(typeof(long), 8, 19, 0);
        public static IBaseType SQLDouble   = new BaseType(typeof(double), 4, 24, 0);
        public static IBaseType SQLFloat    = new BaseType(typeof(float), 8, 53, 0);
        public static IBaseType SQLDecimal  = new BaseType(typeof(decimal), 17, 38, 38);
        public static IBaseType SQLBoolean  = new BaseType(typeof(bool), 1, 1, 0);
        public static IBaseType SQLString   = new BaseType(typeof(string), 8000, 0, 0);
        public static IBaseType SQLChar     = new BaseType(typeof(string), 8000, 0, 0);

        public BaseType(Type type, int? maxLength, int? precision, int? scale) 
        {
            if (maxLength.HasValue && maxLength.Value < 0) throw new ArgumentException("Argument maxLength can't be negative!");
            if (precision.HasValue && precision.Value < 0) throw new ArgumentException("Argument precision can't be negative!");
            if (scale.HasValue && scale.Value < 0)         throw new ArgumentException("Argument scale can't be negative!");  

            this.type      = type;
            this.maxLength = maxLength;
            this.precision = precision;
            this.scale     = scale;
        }

        Type type;
        int? maxLength;
        int? precision;
        int? scale;


        public Type Type
        {
            get { return type; }
        }

        public int? MaxLength
        {
            get { return maxLength; }
        }

        public int? Precision
        {
            get { return precision; }
        }

        public int? Scale
        {
            get { return scale; }
        }
    }
}
