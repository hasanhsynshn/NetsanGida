using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetsanGida.Bll.Helpers
{
    public static class Tool
    {
        public static string CreateUrlSlug(string text)
        {
            try
            {
                text = text.ToUpper().Replace("İ", "I").Replace("Ü", "U").Replace("Ğ", "G").Replace("Ş", "S").Replace("Ö", "O").Replace("Ç", "C");
                text = Translit(text);
                var str = RemoveAccent(text).ToLower();
                str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
                str = Regex.Replace(str, @"\s+", " ").Trim();
                str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
                str = Regex.Replace(str, @"\s", "-");
                return str;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

        private static string RemoveAccent(string txt)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        private static string Translit(string str)
        {
            string[] latUp = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
            string[] latLow = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
            string[] rusUp = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rusLow = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (var i = 0; i <= 32; i++)
            {
                if (str.Contains("I"))
                {
                    str = str.Replace("I", "i");
                }
                else
                {
                    str = str.Replace(rusUp[i], latUp[i]);
                    str = str.Replace(rusLow[i], latLow[i]);
                }
            }
            return str;
        }

        public static bool IsValidEmail(this string emailaddress)
        {
            try
            {
                var m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidPhone(this string tel)
        {
            try
            {
                var a = Regex.Match(tel, @"^(\+[0-9]{10})$").Success;
                return a;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string AppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
