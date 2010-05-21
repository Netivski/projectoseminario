using System;
using System.IO;
using EDM.Generator;

namespace EDM.GeneratorEntryPoint
{
    class Program
    {
        static readonly string DDDFilePath  = null;
        static readonly string XSLTBasePath = null;
        static readonly string GenResult    = null;


        static Program()
        {

            DDDFilePath  = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\3D.xml");
            XSLTBasePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\EDM.Generator\XSLT");
            GenResult    = Path.Combine(Environment.CurrentDirectory, @"..\..\..\3D\GenResult");
        }

        static void Main(string[] args)
        {
            GeneratorFactory.GetInstance(DDDFilePath, XSLTBasePath).Generate(GenResult);
        }
    }
}
