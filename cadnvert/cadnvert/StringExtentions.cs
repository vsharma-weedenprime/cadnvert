using System.Text.RegularExpressions;

namespace cadnvert
{
    public static class StringExtentions
    {
        #region <methods>

        #region <public>

        public static bool IsWildCardMatch(this string str, string wildCardStr)
        {
            if (str == null || wildCardStr == null)
                return false;
            return Regex.IsMatch(str, WildCardToRegular(wildCardStr));
        }

        #endregion </public>

        #region <private>


        private static string WildCardToRegular(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        #endregion </private>

        #endregion </methods>

    }
}
