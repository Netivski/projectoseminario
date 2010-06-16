using System;
using System.IO;

namespace EDM.GeneratorEntryPoint
{
    public class Program
    {
        static readonly string EDMFilePath  = null;
        static readonly string GenResult    = null;


        static Program()
        {

            //EDMFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ISEL.Sample\3D\3D.xml");
            //GenResult   = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ISEL.Sample");

            EDMFilePath = @"D:\DSTS\Personal\my.life\ISEL\3 Ano\PS\Src\ISEL.Sample\3D\3d.xml";
            GenResult   = @"D:\DSTS\Personal\my.life\ISEL\3 Ano\PS\Src\ISEL.Sample";
        }

        static void Main(string[] args)
        {
            EDM.Generator.EntryPoint.Generate(EDMFilePath, GenResult, EDM.Generator.GeneratorTarget.CSharp, EDM.Generator.GeneratortEnvironment.EDMBase);
        }

        public static void SyncWith3D()
        {
            Main(null);
        }

    }
}
