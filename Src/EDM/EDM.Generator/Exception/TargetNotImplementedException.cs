using System;
using EDM.Generator;

namespace EDM.Generator.Exception
{
    internal class TargetNotImplementedException: GeneralException
    {
        public TargetNotImplementedException(GeneratorTarget target) : base(string.Format("Target {0} Not Implemented", target.ToString())) { }
    }
}
