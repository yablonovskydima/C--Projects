
////////////////////////////////////////////////////////
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string date = "";
app.UseWhen(
    context => context.Request.Path == "/date",
    appBuilder => {
        appBuilder.Run(async (context) => {
            var time = DateTime.Now.ToShortDateString();
            await context.Response.WriteAsync($"Time: {time}");
        });
    }
);

app.UseWhen(
    context => context.Request.Path == "/day",
    appBuilder => {
        appBuilder.Run(async (context) => {
            var day = DateTime.Now.Day.ToString();
            await context.Response.WriteAsync($"Day: {day}");
        });
    }
);

app.UseWhen(
    context => context.Request.Path == "/time",
    appBuilder => {
        appBuilder.Run(async (context) => {
            var time = DateTime.Now.ToShortTimeString();
            await context.Response.WriteAsync($"Time: {time}");
        });
    });

app.Map("/time", appBuilder =>
{
    var time = DateTime.Now.ToShortTimeString();
    appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
});

app.Run(async (context) => await context.Response.WriteAsync("hello"));
app.Run();

//async Task GetDate(HttpContext context, RequestDelegate next)
//{
//    string? path = context.Request.Path.Value.ToLower();
//    if (path == "/date")
//    {
//        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
//    }
//    else
//    {
//        await next.Invoke(context);
//    }
//}

/////////////////////////////////////
//app.UseToken("12345678");
//app.Run(async (context) => await context.Response.WriteAsync("hello"));
//public class TokeMiddleware
//{
//    private readonly RequestDelegate next;
//    string pattern;
//    public TokeMiddleware(RequestDelegate next, string pattern)
//    {
//        this.next = next;
//        this.pattern = pattern;
//    }
//    public async Task InvokeAsync(HttpContext context)
//    {
//        var token = context.Request.Query["token"];
//        if (token != pattern)
//        {
//            context.Response.StatusCode = 403;
//            await context.Response.WriteAsync("Token is invalid");
//        }
//        else
//            await next.Invoke(context);
//    }
//}

//public static class TokenExtentions
//{
//    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
//    {
//        return builder.UseMiddleware<TokeMiddleware>(pattern);
//    }
//}
/////////////////////////////////////////////////////
//builder.Services.AddTransient<ICounter, RandomCounter>();
//builder.Services.AddTransient<CounterService>();
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;

//    response.ContentType = "text/html; charset=utf-8";
//    if (request.Path == "/upload" && request.Method == "POST")
//    {
//        IFormFileCollection files = request.Form.Files;
//        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
//        Directory.CreateDirectory(uploadPath);

//        foreach (var file in files)
//        {
//            string fullPath = $"{uploadPath}/{file.FileName}";

//            using (var filestream = new FileStream(fullPath, FileMode.Create))
//            {
//                await file.CopyToAsync(filestream);
//            }
//        }
//        await response.WriteAsync("File load successful");
//    }
//    else
//    {
//        await response.SendFileAsync("uploadform.html");
//    }
//});

//app.Run();
//app.UseMiddleware<CounterMiddleware>();

//app.Run();
//public interface ICounter 
//{
//    int Value { get; }
//}

//public class RandomCounter : ICounter 
//{
//    static Random rand = new Random();
//    private int _value;
//    public RandomCounter() 
//    {
//        _value = rand.Next(0,10000);
//    }
//    public int Value 
//    {
//        get { return _value; }
//    }
//}

//public class CounterService 
//{
//    public ICounter Counter { get; }
//    public CounterService(ICounter counter) 
//    {
//        Counter = counter;
//    }
//}

//public class CounterMiddleware 
//{
//    RequestDelegate next;
//    int i = 0;
//    public  CounterMiddleware(RequestDelegate next) 
//    {
//        this.next = next;
//    }
//    public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService counterService) 
//    {
//        i++;
//        context.Response.ContentType = "text/html; charset=utf-8";
//        await context.Response.WriteAsync($"запит {i}; Conter: {counter.Value}; Service: {counterService.Counter.Value}");
//    }
//}

//interface ITimeService 
//{
//    string GetTime();
//}

//class ShortTimeService : ITimeService 
//{
//    public string GetTime() => DateTime.Now.ToShortTimeString();
//}

//class LongTimeService : ITimeService 
//{
//    public string GetTime() => DateTime.Now.ToLongTimeString();
//}

//class Logger 
//{
//    public void Log(string message) 
//    {
//        Console.WriteLine(message);
//    }
//}

//class Message
//{
//    Logger logger = new Logger();
//    public string Text { get; set; }
//    public void Print()
//    {
//        logger.Log(Text);
//    }
//}