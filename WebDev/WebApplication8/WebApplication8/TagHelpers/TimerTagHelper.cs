using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication8.TagHelpers
{
    //public class TimerTagHelper : TagHelper
    //{
    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        output.TagName = "div";
    //        output.TagMode = TagMode.StartTagAndEndTag;

    //        output.PreElement.SetHtmlContent("<h4>Date and time</h4>");
    //        output.PostElement.SetHtmlContent($"<div>Date: {DateTime.Now.ToString("dd/MM/yyyy")}");

    //        output.Content.SetContent($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
    //        output.Attributes.SetAttribute("style", "color:red");
            
    //    }
    //}

    public class TimerTagHelper : TagHelper 
    {
        public bool SecondsIncluded { get; set; }
        public bool YearIncluded { get; set; }
        public string? Color { get; set; }
        public string? SizeInPX { get; set; }

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
            if (Color != null) output.Attributes.SetAttribute("style", $"color: {Color}");
            if (SizeInPX != null) output.Attributes.SetAttribute("style", $"font-size: {SizeInPX}px");

            output.Content.SetContent(time);
        }
    }

    public class DateTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent($"Current Time: {DateTime.Now.ToString("dd:MM:yyyy")}");
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
