using System;
using System.IO;

namespace EDM.GeneratorEntryPoint
{
    class Program
    {
        static readonly string EDMFilePath  = null;
        static readonly string GenResult    = null;


        static Program()
        {

            EDMFilePath  = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\3D.xml");            
            GenResult    = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\");
        }

        static void Main(string[] args)
        {
            EDM.Generator.EntryPoint.Generate(EDMFilePath, GenResult, EDM.Generator.GeneratorTarget.CSharp, EDM.Generator.GeneratortEnvironment.EDMBase);
        }
    }
}
