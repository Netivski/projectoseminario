using System;

namespace FutureView.ECom.Services.Util.EMail.Template
{
    internal interface ITemplate
    {
        string Subject { get; }
        string Body { get; }
    }
}
