using Microsoft.AspNetCore.Razor.TagHelpers;

namespace exam_second_try.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{output.Content.GetContent()}");
            output.Content.SetContent(output.Content.GetContent());
        }
    }
}
