using System;
using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    /// <summary>
    /// HTTP アクセス用のユーティリティー
    /// </summary>
    public class HttpUtils()
    {
        /// <summary>
        /// HTTP GET コールした結果を取得する
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="path"></param>
        /// <returns>HttpResponseMessage オブジェクト</returns>
        public static async Task<HttpResponseMessage> GetHttpResponseAsync([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string path)
        {
            using (var client = new HttpClient())
            {
                return await GetHttpResponseAsync(endWithSlash(baseUrl) + path);
            }
        }
        public static async Task<HttpResponseMessage> GetHttpResponseAsync([StringSyntax(StringSyntaxAttribute.Uri)] string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }

        /// <summary>
        /// HTTP GET コールした結果を取得する
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="url"></param>
        /// <returns>HttpResponseMessage オブジェクト</returns>
        public static HttpResponseMessage GetHttpResponse([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string? url, int timeoutMillis = 3000)
        {
            Task<HttpResponseMessage> response = (url == null)
                ? GetHttpResponseAsync(baseUrl) : GetHttpResponseAsync(baseUrl, url);

            response.Wait(timeoutMillis);
            return response.Result;

        }
        public static HttpResponseMessage GetHttpResponse([StringSyntax(StringSyntaxAttribute.Uri)] string url, int timeoutMillis = 3000)
        {
            Task<HttpResponseMessage> response = GetHttpResponseAsync(url);

            response.Wait(timeoutMillis);
            return response.Result;
        }

        /// <summary>
        /// HTTP GET コールした結果の文字列を取得する
        /// </summary>
        /// <returns>HTTP GET の結果の文字列</returns>
        public static async Task<string?> GetAsync([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string? url = null)
        {
            var response = await GetHttpResponseAsync(baseUrl, url);
            if (response.IsSuccessStatusCode == false) { return null; }
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// HTTP GET コールした結果の文字列を取得する
        /// </summary>
        /// <returns>HTTP GET の結果の文字列</returns>
        public static string? Get([StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl, string? url = null, int timeoutMillis = 3000)
        {
            var response = GetHttpResponse(baseUrl, url, timeoutMillis);
            if (response.IsSuccessStatusCode == false) { return null; }
            return response.Content.ReadAsStream().ToString();
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
        private static Supplier<T> IfOr<T>(bool condition, Supplier<T> trueCase, Supplier<T> falseCase)
        {
            if (condition) return trueCase;
            return falseCase;
        }
    }
}
