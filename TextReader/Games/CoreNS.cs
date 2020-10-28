using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextReader
{
    class CoreNS : GameReader
    {
        public Dictionary<GameLanguage, string> SupportedLanguage;

        public CoreNS(GameType type) : base(type)
        {
            SupportedLanguage = new Dictionary<GameLanguage, string>()
            {
                { GameLanguage.JPN_KANA, "JPN" },
                { GameLanguage.JPN_KANJI, "JPN_KANJI" },
                { GameLanguage.ENG, "English" },
                { GameLanguage.FRE, "French" },
                { GameLanguage.ITA, "Italian" },
                { GameLanguage.GER, "German" },
                { GameLanguage.SPA, "Spanish" },
                { GameLanguage.KOR, "Korean" },
                { GameLanguage.CHS, "Simp_Chinese" },
                { GameLanguage.CHT, "Trad_Chinese" },
            };
        }

        public void Export(string inputFolder, string rawFolder)
        {
            foreach (var kv in SupportedLanguage)
            {
                var filelist = Directory.GetFiles(Path.Combine(inputFolder, kv.Value), "*.dat", SearchOption.AllDirectories);

                foreach (var inputFile in filelist)
                {
                    var text = new TextFile(inputFile);
                    var ahtb = new AHTB(inputFile.Replace(".dat", ".tbl"));

                    var dict = ahtb.Entries.Zip(text.Entries, (key, value) => $"{key.Item2}={value}").ToArray();
                    var rawFile = Path.Combine(rawFolder, inputFile.Replace(inputFolder, "").Replace(kv.Value, LanguageHelper.ToCode(kv.Key)).Replace(".dat", ".txt"));
                    Directory.CreateDirectory(Path.GetDirectoryName(rawFile));
                    File.WriteAllLines(rawFile, dict);
                }
            }
        }
    }
}
