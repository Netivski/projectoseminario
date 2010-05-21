using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.Generator
{
    public static class GeneratorFactory
    {
        public static IGenerator GetInstance(String edmFilePath, string genResultPath)
        {
            return new Generator(edmFilePath, genResultPath);
        }
    }
}
