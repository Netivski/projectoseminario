using System;
using System.IO;
using System.Text;
using EDM.Generator.Exception;
using EDM.Generator.Context;

namespace EDM.Generator.Engine
{
    internal class GeneratedFileInfo
    {
        public GeneratedFileInfo(string templateName, string outputFile, string xPath, bool mandatory)  
        {
            if (templateName == null) throw new ArgumentNullException("templateName");
            if (outputFile   == null) throw new ArgumentNullException("outputFile");
            if (xPath        == null) throw new ArgumentNullException("xPath");


            this.template     = templateName;
            this.outputFile   = new FileInfo(outputFile);
            if (!this.outputFile.Directory.Exists) throw new InvalidOutputDirectoryException(this.outputFile.Directory.FullName);
            this.xPath        = xPath;   
            this.mandatory    = mandatory;
        }

        public GeneratedFileInfo(string templateName, string outputFile, string xPath, bool mandatory, Encoding outputEncoding): this( templateName, outputFile, xPath,mandatory )
        {
            this.outputEncoding = outputEncoding;
        }

        string   template       = null;
        FileInfo outputFile     = null;
        Encoding outputEncoding = Encoding.UTF8;
        string   xPath          = null;
        bool     mandatory      = false;

        public string   TemplateName   { get { return template; } }
        public FileInfo OutputFile     { get { return outputFile; } }
        public Encoding OutputEncoding { get { return outputEncoding; } }
        public string   XPath          { get { return xPath; } }
        public bool     Mandatory      { get { return mandatory; } }
   

        public string GetOutputFile(params string[] values)
        {
            return string.Format(OutputFile.FullName, values);
        }
    }
}
