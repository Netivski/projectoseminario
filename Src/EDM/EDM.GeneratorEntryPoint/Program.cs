using System;
using System.IO;
using System.Reflection;

namespace EDM.GeneratorEntryPoint
{
    public class Program
    {
        static readonly string ThreeDFilePath  = null;
        static readonly string GenResult       = null;


        static Program()
        {

            ThreeDFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\FutureView.ECom\3D\3D.xml");
            GenResult      = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\FutureView.ECom");            
        }

        static void Main(string[] args)
        {
            EDM.Generator.EntryPoint.Generate(ThreeDFilePath, GenResult, EDM.Generator.GeneratorTarget.CSharp, EDM.Generator.GeneratorEnvironment.EDMBase);
        }

        public static void SyncWith3D()
        {
            Main(null);
        }

    }
}
