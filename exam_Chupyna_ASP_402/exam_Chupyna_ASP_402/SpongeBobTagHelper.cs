using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace exam_Chupyna_ASP_402
{
    public class SpongeBobCaseTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = output.Content.GetContent();
            var result = new StringBuilder();
            for (int i = 0; i < content.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result.Append(char.ToLower(content[i]));
                }
                else
                {
                    result.Append(char.ToUpper(content[i]));
                }
            }
            output.Content.SetContent(result.ToString());
        }
    }
}
