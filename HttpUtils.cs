using System.Diagnostics.CodeAnalysis;
using System.Text;
using static System.Net.WebRequestMethods;

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
        public static async Task<string?> GetAsync([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string? url)
        {

            using (var client = new HttpClient())
            {

                string requestUrl = baseUrl + url.OrStr("");

                string reqBase = IfElse(baseUrl.EndsWith("/")
                    , () => baseUrl
                    , () => baseUrl + "/");
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode == false)
                {
                    return null;
                }
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }


        private delegate T Supplier<T>();

        private static T IfElse<T>(Boolean condition, Supplier<T> trueCase, Supplier<T> falseCase)
        {
            if (condition) return trueCase();
            return falseCase();
        }
    }
}
