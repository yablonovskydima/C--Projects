//context.Response.ContentType = "text/html; charset=utf-8";
//var stringBuilder = new System.Text.StringBuilder("<h3>Parameters of request</h3><table>");
//stringBuilder.Append("<tr><td>Parameter</td><td>Value</td></tr>");
//foreach(var par in context.Request.Query) 
//{
//    stringBuilder.Append($"<tr><td>{par.Key}</td><td>{par.Value}</td></tr>");
//}
//stringBuilder.Append("</table>");
//await context.Response.WriteAsync(stringBuilder.ToString());

//var path = context.Request.Path;
//var fullpath = $"html/{path}";
//var response = context.Response;

//response.ContentType = "text/html; charset=utf-8";
//if (File.Exists(fullpath))
//{
//    await response.SendFileAsync(fullpath);
//}
//else 
//{
//    response.StatusCode = 404;
//    await response.WriteAsync("<h2>Not Found</h2>");
//}

//context.Response.ContentType = "text/html; charset-utf-8";
//if(context.Request.Path == "/postuser") 
//{
//    var form = context.Request.Form;
//    string name = form["name"];
//    string age = form["age"];
//    string[] languages = form["languages"];
//    string langList = "";
//    foreach(var lang in languages) 
//    {
//        langList += $"{lang} ";
//    }
//    await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p><p>Languages: {langList}</p></div>");
//}
//else 
//{
//    await context.Response.SendFileAsync("html/index.html");
//}

//if (context.Request.Path == "/old") 
//{
//    await context.Response.Redirect(https://mystat.itstep.org/ru/main/dashboard/page/index);
//}
//else if (context.Request.Path == "/new") 
//{
//    await context.Response.WriteAsync("New page");
//}
//else 
//{
//    await context.Response.WriteAsync("Main page");
//}

//app.Run(async (context) =>
//{


//    //var response = context.Response;
//    //var request = context.Request;

//    //if (request.Path == "/api/user") 
//    //{
//    //    var message = "Incorrect data";
//    //    try
//    //    {
//    //        var person = await request.ReadFromJsonAsync<Person>();
//    //        if (person != null)
//    //        {
//    //            message = $"Name: {person.Name} Age: {person.Age}";
//    //        }
//    //    }
//    //    catch {}
//    //    await response.WriteAsJsonAsync(new { text = message });
//    //}
//    //else 
//    //{
//    //    response.ContentType = "text/html; charset=utf-8";
//    //    await response.SendFileAsync("html/index.html");
//    //}



//});

var builder = WebApplication.CreateBuilder();
var app  = builder.Build();

app.Map("/", (HttpContext context) => {  context.Response.WriteAsync("app is working"); });

app.Map("/htmlpage", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/hmwrk.html");
});



app.Run();

public record Person(string Name, int Age);
