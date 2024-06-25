using Microsoft.AspNetCore.Mvc;

namespace MVC1
{
    public class HtmlResult
    {
        string htmlCode;
        public HtmlResult(string html) 
        {
            htmlCode = html;

        }
        public async Task ExecResultAsync(ActionContext context) 
        {
            string fullHtmlCode = @$"<!DOCTYPE html>
                                    <html>
                                        <head>
                                            <title>Some Title</title>
                                            <meta charsrt='utf-8'/>
                                        </head>
                                        <body>
                                            <h2> {htmlCode} <h2/>
                                        <body>
                                    </html>";
            context.HttpContext.Response.ContentType = "text/html; charset=utf-8";
            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
