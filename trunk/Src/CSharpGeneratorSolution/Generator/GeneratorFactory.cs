using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public static class GeneratorFactory
    {
        public static IGenerator getInstance(String xmlFileLocation, String xslBag)
        {
            return new Generator(xmlFileLocation, xslBag);
        }
    }
}
