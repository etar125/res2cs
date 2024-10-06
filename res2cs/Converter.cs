using System;
using System.Collections.Generic;

namespace res2cs {
    public class Converter {
        // Изменённый метод из ReScript
        private string ConvertS(string src) {
            string[] ofas2 = src.Split(new string[] { "&&&", "&^&" }, StringSplitOptions.None);
            string result = "";
            for (int s = 0; s < ofas2.Length; s++) {
                if (ofas2[s].StartsWith("$")) result += ofas2[s].Remove(0, 1) + " +";
                else if (ofas2[s].StartsWith("/$")) result += "\"" + ofas2[s].Remove(0, 1) + "\" +";
                else result += "\"" + ofas2[s] + "\" +";
            }
            if (result.EndsWith(" +")) result.Remove(result.Length - 3);
            return result;
        }

        public string[] res2cs(string[] code) {
            char[] TrimChars = { ' ', '\t' };
            List<string> res = new List<string> {
                "using System;",
                "using System.Windows.Forms;",
                "namespace App {",
                "\tclass Program {",
                "\t\tpublic static void Main(string[] args) {",
            };
            string b;
            string tmp;
            foreach (string a in code) {
                b = a.TrimStart(TrimChars).ToLower();
                // vvv Взято из ReScript
                if (b[0] != '_') b = b.Substring(0, 1).ToUpper() + b.Substring(1);
                else b = "_" + b.Substring(1, 1).ToUpper() + b.Substring(2);

                // Команды для Hello, World
                // потом уберу этот комментарий
                if (b.StartsWith("Printline")) {
                    tmp = b.Substring(9);
                    res.Add("\t\t\tConsole.WriteLine(" + ConvertS(tmp) + ");");
                } else if (b.StartsWith("Pause")) {
                    tmp = b.Substring(5);
                    res.Add("\t\t\tConsole.ReadKey(true);");
                }
            }

            res.AddRange(new List<string> {
                "\t\t}",
                "\t}",
                "}",
            });
            return res.ToArray();
        }
    }
}
