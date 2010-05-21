using System;
using System.IO;
using EDM.Generator;

namespace EDM.GeneratorEntryPoint
{
    class Program
    {
        static readonly string EDMFilePath  = null;
        static readonly string GenResult    = null;


        static Program()
        {

            EDMFilePath  = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\3D.xml");            
            GenResult    = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\GenResult");
        }

        static void Main(string[] args)
        {
            GeneratorFactory.GetInstance(EDMFilePath, GenResult).Generate();
        }
    }
}
