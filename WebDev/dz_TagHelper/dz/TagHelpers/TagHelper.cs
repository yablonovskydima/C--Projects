using Microsoft.AspNetCore.Razor.TagHelpers;

namespace dz.TagHelpers
{
    public class TimerTagHelper : TagHelper
    {
        public bool SecondsIncluded { get; set; }
        public bool YearIncluded { get; set; }
        public string? SizeInPX { get; set; }
        public string? Color { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var now = DateTime.Now;
            var time = String.Empty;
            if (SecondsIncluded)
                time = now.ToString("HH:mm:ss");
            else if (YearIncluded)
                time = now.ToString("HH:mm/yyyy");
            else
                time = now.ToString("HH:mm");

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (SizeInPX != null) output.Attributes.Add("style", $"font-size: {SizeInPX}px");
            if (Color != null) output.Attributes.Add("style", $"color: {Color}");

            

            output.Content.SetContent(time);
        }
    }

    public class FormTagHelper : TagHelper 
    {
        public string? SizeInPx { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output) 
        {
            output.TagName = "form";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (SizeInPx != null) output.Attributes.SetAttribute("style", $"font-size: {SizeInPx}px");
            var content = @"<form method='post'>
                                <p>
                                    <label> Email </label><br/>
                                    <input type = 'email'/>
                                </p>
                                <p>
                                    <label> Password </label><br/>
                                    <input type = 'password'/>
                                </p>
                                <p>
                                    <input type = 'submit'/>
                                </p>
                            </form>";
            output.Content.SetHtmlContent(content);
        }

    }

    public class DateTagHelper : TagHelper
    {
        public string? SizeInPx { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            if (SizeInPx != null) output.Attributes.SetAttribute("style", $"font-size: {SizeInPx}px");
            output.Content.SetContent($"Current Time: {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }

    public class BTagHelper : TagHelper 
    {
        public override void Process(TagHelperContext context, TagHelperOutput output) 
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = "<br/><br/><br/><br/>";
            output.Content.SetHtmlContent(content);
        }
    }

    public class SummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var target = await output.GetChildContentAsync();
            var content = "<h3>Overall info</h3>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }
}
