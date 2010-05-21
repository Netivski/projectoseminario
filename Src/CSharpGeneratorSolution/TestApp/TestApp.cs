﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator;

namespace TestApp
{
    public class TestApp
    {
        public static void Main(string[] args)
        {
            //IGenerator gen = GeneratorFactory.getInstance(@"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\XML\typeModel.xml",
            //    @"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\XSLT");
            //gen.generate(@"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\Generated");
            IGenerator gen = GeneratorFactory.getInstance(@"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\XML\entity.xml",
                @"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\XSLT");
            gen.generate(@"C:\ISEL\PES\trunk\Src\CSharpGeneratorSolution\Generator\Generated");
        }
    }
}
