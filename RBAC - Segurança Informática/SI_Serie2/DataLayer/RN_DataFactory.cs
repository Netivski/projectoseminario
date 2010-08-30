using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class RN_DataFactory
    {
        public static IRN_DataLayer getInstance(String dataType)
        {
            switch (dataType)
            {
                case "SqlServer":
                    return new RN_DataLayer_Sql();                    
                default:
                    throw new Exception("DataType not supported.");
            }
        }
    }
}
