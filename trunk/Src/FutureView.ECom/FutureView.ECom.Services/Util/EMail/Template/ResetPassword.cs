using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FutureView.ECom.Services.Util.EMail.Template
{
    internal class ResetPassword: ITemplate
    {
        public string Subject
        {
            get { return "FutureView - Reset Password"; }
        }

        public string Body
        {
            get { return "A sua password de acesso à FutureView é {0}."; }
        }
    }
}
