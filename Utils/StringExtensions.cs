namespace Utils
{
    /// <summary>
    /// string 型に対する拡張メソッド
    /// </summary>
    public static class StringExtensions
    {
        public static string OrStr(this string? str, string orValue = "")
        {
            if (str == null || str.Length == 0 || str.Trim().Length == 0) return orValue;
            return str;
        }
        /// <summary>
        /// 末尾が "/" の場合、末尾の "/" を削除した文字列を返却する
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeleteLastCharSlash(this string? str)
        {
            if (str == null || str.Length == 0 || str.Trim().Length == 0) return "";
            if (str.EndsWith("/")) return str.Substring(0, str.Length - 1);
            return str;
        }
    }
}
