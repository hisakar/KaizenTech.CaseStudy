using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaizenTech.CaseStudy
{
    public class Q1
    {
        const string CHAR_SET = "ACDEFGHKLMNPRTXYZ234579";
        // 0 ... 22 indexes
        const int VALID_CODE_LENGTH = 8;
        public void Solve()
        {
            var codes = GenerateCodes();
            codes.ForEach(c => Console.WriteLine(c));
            var input = "";
            while (input != "exit")
            {
                input = Console.ReadLine();
                Console.WriteLine(input + " code is valid: " + CodeIsValid(input));
                Console.WriteLine(input + " code exists in generated codes: " + codes.Any(c => c == input));
            }
        }

        private bool CodeIsValid(string code)
        {
            try
            {
                if (code.Length != VALID_CODE_LENGTH) return false;
                var codeIndexes = new List<int>();
                var sumOfIndexes = code.Sum(c =>
                {
                    var indexOf = CHAR_SET.IndexOf(c);
                    if (indexOf == -1) throw new Exception("Invalid character " + c);
                    codeIndexes.Add(indexOf);
                    return indexOf;
                });
                if (sumOfIndexes < VALID_CODE_LENGTH * CHAR_SET.Length / 3)
                    return false;

                if (codeIndexes[0] * codeIndexes[5] < 5)
                    return false;

                if (codeIndexes[1] * codeIndexes[3] < 3)
                    return false;

                if (codeIndexes[2] * codeIndexes[7] < 7)
                    return false;

                if (codeIndexes[4] * codeIndexes[6] < 6)
                    return false;

                return true;
            }
            catch (Exception e) { return false; }
        }

        public List<string> GenerateCodes()
        {
            List<string> codes = new List<string>();

            while (codes.Count() < 1000)
            {
                var random = new Random();
                var charSet = new string(CHAR_SET.ToArray());
                var code = "";
                for (int i = 0; i < VALID_CODE_LENGTH; i++)
                {
                    var max = charSet.Length - 1;
                    var randomIndex = random.Next(max);
                    var randomChar = charSet[randomIndex];
                    code += randomChar;
                    charSet.Remove(randomIndex);
                }
                if (!codes.Contains(code) && CodeIsValid(code))
                    codes.Add(code);
            }

            return codes;
        }

    }

}
