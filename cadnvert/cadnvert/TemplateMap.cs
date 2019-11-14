using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace cadnvert
{
    public static class TemplateMap
    {
        public static Dictionary<string, string> Map { get; } = new Dictionary<string, string>()
        {
            { @"cadntrde*", @"HeaderTemplates\01.1_Global Activity Layout.xlsx" },
            { @"cadnfutt*", @"HeaderTemplates\27.0 Futures Activity File.xlsx" },
            { @"cadnimkp*", @"HeaderTemplates\45.0 Daily Interest Mark–up.xlsx" },
            { @"cadnsmkp*", @"HeaderTemplates\44.0_Daily Short Stock Mark-up.xlsx" },
        };

        public static string GetTemplate(string fileName)
        {
            foreach (var fileTemplateMapItem in Map.Where(fileTemplateMapItem => fileName.IsWildCardMatch(fileTemplateMapItem.Key)))
            {
                return new Uri( Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), fileTemplateMapItem.Value)).AbsoluteUri;
            }
            return string.Empty;
        }
    }
}
