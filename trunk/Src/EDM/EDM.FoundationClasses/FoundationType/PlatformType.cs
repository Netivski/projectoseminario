using System;
using System.Data;

namespace EDM.FoundationClasses.FoundationType
{
    public class PlatformType: IPlatformType
    {
        public static IPlatformType UString     = new PlatformType(typeof(string), null, null, null);
        public static IPlatformType UShort      = new PlatformType(typeof(short), null, null, null);
        public static IPlatformType UInt        = new PlatformType(typeof(int), null, null, null);
        public static IPlatformType ULong       = new PlatformType(typeof(long), null, null, null);
        public static IPlatformType UDecimal    = new PlatformType(typeof(decimal), null, null, null);
        public static IPlatformType UDouble     = new PlatformType(typeof(double), null, null, null);
        public static IPlatformType UGuid       = new PlatformType(typeof(Guid), null, null, null);
        public static IPlatformType UDateTime   = new PlatformType(typeof(DateTime), null, null, null);
        public static IPlatformType UFloat      = new PlatformType(typeof(float), null, null, null);
        public static IPlatformType UBinary     = new PlatformType(typeof(byte), null, null, null);        

        public static IPlatformType SQLGuid     = new PlatformType(typeof(Guid), 16, null, null);
        public static IPlatformType SQLDateTime = new PlatformType(typeof(DateTime), 8, 23, 3);
        public static IPlatformType SQLInt      = new PlatformType(typeof(int), 4, 10, 0);
        public static IPlatformType SQLLong     = new PlatformType(typeof(long), 8, 19, 0);
        public static IPlatformType SQLDouble   = new PlatformType(typeof(double), 4, 24, 0);
        public static IPlatformType SQLFloat    = new PlatformType(typeof(float), 8, 53, 0);
        public static IPlatformType SQLDecimal  = new PlatformType(typeof(decimal), 17, 38, 38);
        public static IPlatformType SQLBoolean  = new PlatformType(typeof(bool), 1, 1, 0);
        public static IPlatformType SQLString   = new PlatformType(typeof(string), 8000, 0, 0);
        public static IPlatformType SQLChar     = new PlatformType(typeof(string), 8000, 0, 0);

        public PlatformType(Type type, int? maxLength, int? precision, int? scale) 
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
