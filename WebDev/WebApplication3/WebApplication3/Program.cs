//builder.Configuration.AddInMemoryCollection(new Dictionary<string, string> 
//{
//    {"name", "Sam"},
//    {"age", "22" }
//});

//app.UseStaticFiles();
//app.Run(async (context) => 
//{
//    await context.Response.WriteAsync("hello");
//});

//app.Configuration["name"] = "testname";
//app.Configuration["age"] = "99";

//app.Run(async (context) => 
//{
//    string name = app.Configuration["person"];
//    string age = app.Configuration["company"];

//    await context.Response.WriteAsync($"name: {name}, age: {age}");
//});

//app.Map("/", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["company"]}");

//app.Run(async (context) => 
//{
//    app.Logger.LogInformation($"Processing request{context.Request.Path}");
//    app.Logger.LogWarning($"Processing request{context.Request.Path}");
//    await context.Response.WriteAsync("hello");
//});

//var loggerFactory = LoggerFactory.Create(builder => 
//{
//    builder.AddDebug();
//    builder.AddConsole();

//    builder.AddFilter("System", LogLevel.Information).AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
//});
//ILogger logger = loggerFactory.CreateLogger<Program>();

//app.Run(async (context) => 
//{
//    logger.LogInformation($"Path: {context.Request.Path}");
//    await context.Response.WriteAsync("Hello");
//});

//app.Use(async (context, next) => 
//{
//    context.Items.Add("message", "Hello wrld");
//    await next.Invoke();

//});

//app.Run(async (context) => 
//{
//    if (context.Request.Cookies.ContainsKey("name"))
//    {
//        string? name = context.Request.Cookies["name"];
//        await context.Response.WriteAsync($"hello {name}");
//    }
//    else
//    {
//        context.Response.Cookies.Append("name", "tom");
//        await context.Response.WriteAsync("added cookie");
//    }
//});

//app.UseSession();

//app.Run(async (context) => 
//{
//    if (context.Session.Keys.Contains("person")) 
//    {
//        Person? person = context.Session.Get<Person>("person");
//        await context.Response.WriteAsync($"Hello {person.Name}, your age: {person.Age}");
//    }
//    else 
//    {
//        Person person = new Person { Name = "Tom", Age = 22 };
//        context.Session.Set<Person>("person", person);
//        await context.Response.WriteAsync("added person");
//    }


//});

//app.Environment.EnvironmentName = "Production";
////app.UseDeveloperExceptionPage();    


//if (!app.Environment.IsDevelopment()) 
//{
//    app.UseExceptionHandler(app => app.Run(async (context) => 
//    {
//        context.Response.StatusCode = 500;
//        await context.Response.WriteAsync($"Error 500 division by zero");
//    }));
//}


//app.Run(async (context) =>
//{
//    int a = 5;
//    int b = 0;
//    int c = a / b;
//    await context.Response.WriteAsync($"c = {c}");
//});

using Microsoft.Extensions.Logging.Debug;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(/*new WebApplicationOptions { WebRootPath = "static" }*/);
//builder.Configuration.AddXmlFile("config.xml");
//builder.Services.AddDistributedMemoryCache().AddSession();
//builder.Services.AddSession();

var app = builder.Build();
app.Map("/red", () => Results.LocalRedirect("/person"));
app.Map("/person", () => Results.Json(new Person { Name = "bob", Age=44}));
app.Map("/", () => Results.Json(new { Name = "tob", Age = 34 }));
app.Map("/contacts", () => Results.NotFound("Error 404"));
app.Map("/send", async () => 
{
    string path = "files/img.png";
    byte[] fileContent = await File.ReadAllBytesAsync(path);
    string contentType = "image/png";
    string downloadName = "LogoASPNET.png";
    return Results.File(fileContent, contentType, downloadName);
});

app.Run();

public static class SessionExtension 
{
    public static void Set<T>(this ISession session, string key, T value) 
    {
        session.SetString(key, JsonSerializer.Serialize<T>(value));
    }

    public static T? Get<T>(this ISession session, string key) 
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
    }
}
class Person 
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
