using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDM.Generator
{
    public interface IGenerator
    {
        void Generate(String destFolder);
    }
}
