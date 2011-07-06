using System;
using System.Collections.Generic;
using System.Text;

namespace netOpen
{
    public class CopyInfo
    {
        public string SourcePath { get; set; }
        public string DestenationPath { get; set; }
        public bool Overwrite { get; set; }

        public CopyInfo()
        {
            Overwrite = false;
        }

        public CopyInfo(string Source,string Destenation)
        {
            SourcePath = Source;
            DestenationPath = Destenation;
            Overwrite = false;
        }

    }
}
