using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace KaizenTech.CaseStudy
{
    internal class Program
    {
        const string CHAR_SET = "ACDEFGHKLMNPRTXYZ234579";
        const int VALID_CODE_LENGTH = 8;
        //
        static void Main(string[] args)
        {
            new Q1().Solve();

            //new Q2().Solve();
        }
    }


}
