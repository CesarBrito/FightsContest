using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FightsContest.Test
{
    public static class Resources
    {
        public static string Get(string query)
        {
            using (
                var stream =
                    Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"FightsContest.Test.Json.{query}"))
            {
                if (stream == null)
                { throw new ArgumentException($"Query not found: {query}"); }

                using (var reader = new StreamReader(stream))
                { return reader.ReadToEnd(); }
            }
        }
    }
}
