namespace Utils
{
    using Markdig;
    /// <summary>
    /// Markdown に関するユーティリティー
    /// </summary>
    public static class MarkdownUtils
    {
        public static string ToHtml(this string str)
        {
            var markdownPipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
            string htmlContents = Markdown.ToHtml(str, markdownPipeline);
            return htmlContents;
        }
    }
}
