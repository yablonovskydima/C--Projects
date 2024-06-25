using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC3
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper htmlHelper, string[] items) 
        {
            string result = "<ul>";
            foreach(string item in items) 
            {
                result = $"{result}<li>{item}</li>";

            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }

        public static HtmlString CreateForm(this IHtmlHelper htmlHelper) 
        {
            string result = @"<form>
                <label>Email</label>
                <input type='email'/>
                <br/>
                <br/>
                <label> Password </label>
                <input type = 'password'/>
                <br/>
                <br/>
                <input type = 'submit'/>
                </form>";
            return new HtmlString(result);
        }
    }
}
