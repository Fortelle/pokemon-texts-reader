using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextReader
{
    class Core3DS : GameReader
    {
        public Dictionary<GameLanguage, string> Common;
        public Dictionary<GameLanguage, string> Script;

        public Core3DS(GameType type) : base(type)
        {
            switch (type)
            {
                case GameType.XY:
                    Common = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "072" },
                        { GameLanguage.JPN_KANJI, "073" },
                        { GameLanguage.ENG, "074" },
                        { GameLanguage.FRE, "075" },
                        { GameLanguage.ITA, "076" },
                        { GameLanguage.GER, "077" },
                        { GameLanguage.SPA, "078" },
                        { GameLanguage.KOR, "079" },
                    };
                    Script = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "080" },
                        { GameLanguage.JPN_KANJI, "081" },
                        { GameLanguage.ENG, "082" },
                        { GameLanguage.FRE, "083" },
                        { GameLanguage.ITA, "084" },
                        { GameLanguage.GER, "085" },
                        { GameLanguage.SPA, "086" },
                        { GameLanguage.KOR, "087" },
                    };
                    break;
                case GameType.ORAS:
                    Common = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "071" },
                        { GameLanguage.JPN_KANJI, "072" },
                        { GameLanguage.ENG, "073" },
                        { GameLanguage.FRE, "074" },
                        { GameLanguage.ITA, "075" },
                        { GameLanguage.GER, "076" },
                        { GameLanguage.SPA, "077" },
                        { GameLanguage.KOR, "078" },
                    };
                    Script = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "079" },
                        { GameLanguage.JPN_KANJI, "080" },
                        { GameLanguage.ENG, "081" },
                        { GameLanguage.FRE, "082" },
                        { GameLanguage.ITA, "083" },
                        { GameLanguage.GER, "084" },
                        { GameLanguage.SPA, "085" },
                        { GameLanguage.KOR, "086" },
                    };
                    break;
                case GameType.SM:
                case GameType.USUM:
                    Common = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "030" },
                        { GameLanguage.JPN_KANJI, "031" },
                        { GameLanguage.ENG, "032" },
                        { GameLanguage.FRE, "033" },
                        { GameLanguage.ITA, "034" },
                        { GameLanguage.GER, "035" },
                        { GameLanguage.SPA, "036" },
                        { GameLanguage.KOR, "037" },
                        { GameLanguage.CHS, "038" },
                        { GameLanguage.CHT, "039" },
                    };
                    Script = new Dictionary<GameLanguage, string>()
                    {
                        { GameLanguage.JPN_KANA, "040" },
                        { GameLanguage.JPN_KANJI, "041" },
                        { GameLanguage.ENG, "042" },
                        { GameLanguage.FRE, "043" },
                        { GameLanguage.ITA, "044" },
                        { GameLanguage.GER, "045" },
                        { GameLanguage.SPA, "046" },
                        { GameLanguage.KOR, "047" },
                        { GameLanguage.CHS, "048" },
                        { GameLanguage.CHT, "049" },
                    };
                    break;
            }
        }

        public void Export(string inputFolder, string rawFolder)
        {
            foreach (var lang in Common.Keys)
            {
                foreach( var group in new string[] { "common", "script" })
                {
                    var dict = group == "common" ? Common : Script;
                    var filelist = Directory.GetFiles(Path.Combine(inputFolder, dict[lang] + "_"));

                    foreach (var inputFile in filelist)
                    {
                        var index = Path.GetFileNameWithoutExtension(inputFile);
                        var text = new TextFile(inputFile);

                        var rawPath = @$"{rawFolder}\{LanguageHelper.ToCode(lang)}\{group}\{index}.txt";
                        Directory.CreateDirectory(Path.GetDirectoryName(rawPath));
                        File.WriteAllLines(rawPath, text.Entries);
                    }
                }
            }
        }
    }
}