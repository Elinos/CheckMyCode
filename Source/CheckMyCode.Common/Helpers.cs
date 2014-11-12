using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMyCode.Data.Models;

namespace CheckMyCode.Common
{
    public static class Helpers
    {
        public static LanguageType GetLanguageType(string filename)
        {
            int fileExtPos = filename.LastIndexOf(".");
            if (fileExtPos < 0)
                return LanguageType.Unknown;
            string extention = filename.Substring(fileExtPos);

            if (extention.StartsWith(".css"))
                return LanguageType.CSS;
            if (extention.StartsWith(".cs"))
                return LanguageType.CSharp;
            if (extention.StartsWith(".rb"))
                return LanguageType.Ruby;
            if (extention.StartsWith(".js") || extention.StartsWith(".json"))
                return LanguageType.JavaScript;
            if (extention.StartsWith(".htm"))
                return LanguageType.HTML;
            if (extention.StartsWith(".py"))
                return LanguageType.Python;
            if (extention.StartsWith(".xml"))
                return LanguageType.XML;
            if (extention.StartsWith(".asp"))
                return LanguageType.ASP;
            
            return LanguageType.Unknown;
        }
    }
}