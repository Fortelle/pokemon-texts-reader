using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader
{
    static class TextFormatter
    {
        private static Regex NewLineRegex = new Regex(@"(^|.)((?:\[0x000A\])+)($|.)");
        public static string Format(string src, GameLanguage lang)
        {
            var dest = src;

            // {}
            // 0x0114: wait?
            // 0xBE00: return
            // 0xBE01: clear
            // 0xBE02: wait
            // 0xBDFF: blank
            if (dest.StartsWith(@"{0xBDFF")) return "";
            dest = Regex.Replace(dest, @"\{0x0114.*?\}", "");
            dest = Regex.Replace(dest, @"\{0x0....*?\}", "<var>");
            dest = Regex.Replace(dest, @"\{0x.....*?\}", "");

            // []
            dest = dest.Replace("[0x0009]", "");
            switch (lang)
            {
                case GameLanguage.JPN_KANA:
                case GameLanguage.JPN_KANJI:
                    dest = NewLineRegex.Replace(dest, m => m.Groups[1].Value + (string.IsNullOrWhiteSpace(m.Groups[1].Value) || string.IsNullOrWhiteSpace(m.Groups[3].Value) || char.IsPunctuation(m.Groups[1].Value[0]) ? "" : "　") + m.Groups[3].Value);
                    break;
                case GameLanguage.CHS:
                case GameLanguage.CHT:
                    dest = dest.Replace("[0x000A]", "");
                    break;
                default:
                    dest = NewLineRegex.Replace(dest, m => m.Groups[1].Value + (string.IsNullOrWhiteSpace(m.Groups[1].Value) || string.IsNullOrWhiteSpace(m.Groups[3].Value) ? "" : " ") + m.Groups[3].Value);
                    break;
            }

            dest = dest.Replace("[0xE07F]", ((char)0x202F).ToString()); // nbsp
            dest = dest.Replace("[0xE085]", "."); // ORAS\de\script\18.txt
            dest = dest.Replace("[0xE087]", "."); // ORAS\es\script\18.txt
            dest = dest.Replace("[0xE08A]", "ᵉʳ");
            dest = dest.Replace("[0xE08B]", "ʳᵉ");
            dest = dest.Replace("[0xE08D]", "…"); // 0x2026
            dest = dest.Replace("[0xE08E]", "♂"); // 0x2642
            dest = dest.Replace("[0xE08F]", "♀"); // 0x2640
            dest = dest.Replace("[0xE092]", "♥"); // 0x2665
            dest = dest.Replace("[0xE09A]", "♪"); // 0x266A
            dest = dest.Replace("[0xE0A6]", "ᵉ");
            dest = dest.Replace("[0xE300]", "₽"); // $ ???



            // ''""
            if (lang == GameLanguage.ENG || lang == GameLanguage.FRE || lang == GameLanguage.GER || lang == GameLanguage.ITA || lang == GameLanguage.SPA)
            {
                dest = dest.Replace("‘", "'");
                dest = dest.Replace("’", "'");
                dest = dest.Replace("“", "\"");
                dest = dest.Replace("”", "\"");
            }

            return dest;
        }

        public static void Format(GameType game, string rawFolder, string plainFolder)
        {
            rawFolder = rawFolder.TrimEnd('\\');
            plainFolder = plainFolder.TrimEnd('\\');
            var filelist = Directory.GetFiles(rawFolder, "*", SearchOption.AllDirectories);
            var rawExcaped = Regex.Escape(rawFolder);
            var inputRegex = new Regex("^" + rawExcaped + @"(\\(.+?)\\.+)$");

            foreach (var inputFile in filelist)
            {
                var m = inputRegex.Match(inputFile);
                var suffix = m.Groups[1].Value;
                var lang = LanguageHelper.ToLanguage(m.Groups[2].Value);

                var text = File.ReadAllLines(inputFile).AsEnumerable();
                if (game == GameType.GPGE || game == GameType.SWSH || game == GameType.Home)
                {
                    text = text.Select(x => x.Split(new[] { '=' }, 2)[1]);
                }

                if ((lang == GameLanguage.CHS && game == GameType.SM && suffix.Contains(@"common\55.txt"))
                    || (lang == GameLanguage.CHS && game == GameType.USUM && suffix.Contains(@"common\60.txt")))
                {
                    text = Properties.Resources.monsname_chs.Split(new string[] { "\r\n" }, StringSplitOptions.None).Take(text.Count());
                }
                else if ((lang == GameLanguage.CHT && game == GameType.SM && suffix.Contains(@"common\55.txt"))
                    || (lang == GameLanguage.CHT && game == GameType.USUM && suffix.Contains(@"common\60.txt")))
                {
                    text = Properties.Resources.monsname_cht.Split(new string[] { "\r\n" }, StringSplitOptions.None).Take(text.Count());
                }
                else
                {
                    text = text.Select(x => TextFormatter.Format(x, lang));
                }

                var plainPath = plainFolder + suffix;
                Directory.CreateDirectory(Path.GetDirectoryName(plainPath));
                File.WriteAllLines(plainPath, text);
            }
        }
    }
}
