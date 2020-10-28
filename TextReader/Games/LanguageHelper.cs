using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    static class LanguageHelper
    {
        private static Dictionary<GameLanguage, string> LanguageCode = new Dictionary<GameLanguage, string> {
            {GameLanguage.JPN_KANA,  "ja-Hrkt" },
            {GameLanguage.JPN_KANJI, "ja-Jpan" },
            {GameLanguage.ENG,       "en" },
            {GameLanguage.FRE,       "fr" },
            {GameLanguage.ITA,       "it" },
            {GameLanguage.GER,       "de" },
            {GameLanguage.SPA,       "es" },
            {GameLanguage.KOR,       "ko" },
            {GameLanguage.CHS,       "zh-Hans" },
            {GameLanguage.CHT,       "zh-Hant" },
        };

        public static string ToCode(GameLanguage lang)
        {
            return LanguageCode[lang];
        }

        public static GameLanguage ToLanguage(string code)
        {
            return LanguageCode.First(kv=>kv.Value == code).Key;
        }
    }
}
