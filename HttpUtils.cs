using System.Diagnostics.CodeAnalysis;

namespace markdown_wsam
{
    /// <summary>
    /// HTTP アクセス用のユーティリティー
    /// </summary>
    public class HttpUtils()
    {

        /// <summary>
        /// HTTP GET コールした結果の文字列を取得する
        /// </summary>
        /// <returns>HTTP GET の結果の文字列</returns>
        public static async Task<string?> GetAsync([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string? url = null)
        {

            using (var client = new HttpClient())
            {
                Supplier<string> reqUriFunc = IfOr(url == null, () => baseUrl
                    , () => endWithSlash(baseUrl) + url);
                HttpResponseMessage response = await client.GetAsync(reqUriFunc());

                if (response.IsSuccessStatusCode == false)
                {
                    return null;
                }
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        private static string endWithSlash(string baseUrl)
        {
            var reqBase = IfOr(baseUrl.EndsWith("/"), () => baseUrl
                , () => baseUrl + "/");
            return reqBase();

        }

        private delegate T Supplier<T>();

        /// <summary>
        /// condition の条件を満たした場合、 trueCase の関数を返却。満たさない場合は falseCase の関数を返却
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">判定条件</param>
        /// <param name="trueCase">true の場合の Supplier</param>
        /// <param name="falseCase">false の場合の Supplier</param>
        /// <returns></returns>
        private static Supplier<T> IfOr<T>(Boolean condition, Supplier<T> trueCase, Supplier<T> falseCase)
        {
            if (condition) return trueCase;
            return falseCase;
        }
    }
}
