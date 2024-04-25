using Microsoft.AspNetCore.Razor.TagHelpers;

namespace exam_Chupyna_ASP_402
{
    public class AntiCapsTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(output.Content.GetContent().ToLower());
        }
    }
}
