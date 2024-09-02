namespace Utils
{
    /// <summary>
    /// string 型に対する拡張メソッド
    /// </summary>
    public static class PathUtils22222
    {
        public static string FileExtension2222(this string? str)
        {
            if (str == null || str.Length == 0 || str.Trim().Length == 0) return "";
            string fileExtension = Path.GetExtension(str);
            return fileExtension;
        }
    }
}
