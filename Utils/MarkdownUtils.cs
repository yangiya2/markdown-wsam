namespace Utils
{
    using Markdig;
    using Markdig.Extensions.AutoIdentifiers;

    /// <summary>
    /// Markdown に関するユーティリティー
    /// </summary>
    public static class MarkdownUtils
    {
        public static string ToHtml(this string str)
        {
            var markdownPipeline = new MarkdownPipelineBuilder()
                .UsePipeTables()
                .UseAdvancedExtensions() // 追加の拡張機能を使用
                .UseAutoIdentifiers(AutoIdentifierOptions.GitHub) // ヘッダーにIDを追加
                .Build();

            //var markdownPipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
            string htmlContents = Markdown.ToHtml(str, markdownPipeline);
            return htmlContents;
        }
    }
}
