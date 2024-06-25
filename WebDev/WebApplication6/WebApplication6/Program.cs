using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var people = new List<Person>
{
    new Person("tom@gmail.com", "12345", "User"),
    new Person("bob@gmail.com", "54321", "Admin"),
    new Person("sam@gmail.com", "11111", "VIP")
};

var builder = WebApplication.CreateBuilder();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/login";
});
builder.Services.AddTransient<IAuthorizationHandler, AgeHandler>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyForLondon", policy =>
    {
        policy.RequireClaim(ClaimTypes.Locality, "London");
    });

    options.AddPolicy("OnlyForMicrosoft", policy =>
    {
        policy.RequireClaim("company", "Microsoft");
    });

    options.AddPolicy("OnlyForVIPS", policy => 
    {
        policy.RequireClaim("VIP", "Yes");
    });
    options.AddPolicy("ForAdmins", policy => 
    {
        policy.RequireClaim("Status", "Admin");
    });

    options.AddPolicy("ForVIPs", policy =>
    {
        policy.RequireClaim("Status", "VIP");
    });

    options.AddPolicy("AgeLimit", policy => policy.Requirements.Add(new AgeRequirement(18)));
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    string loginform = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset=""utf - 8""/>
        <title> Lesson </title>
    </head>
    <body>
        <h2> Login Form </h2>
        <form method = 'post'>
            <p>
                <label> Email </label><br/>
                <input name = 'email'/>
            </p>
            <p>
                <label> Password </label><br/>
                <input type = 'password' name = 'password'/>
            </p>
            <input type = 'submit' value = 'Login'/>
        </form>
    </body>
    </html> ";
    await context.Response.WriteAsync(loginform);
});

app.MapPost("/login", async (string? returnUrl, HttpContext context) => 
{
    var form = context.Request.Form;
    if(!form.ContainsKey("email") || !form.ContainsKey("password")) 
    {
        return Results.BadRequest("Email or pass is invalid");
    }

    string email = form["email"];
    string password = form["password"];

    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);

    if (person is null) return Results.Unauthorized();
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, person.Email),
        new Claim("Status", person.Status)
        //new Claim(ClaimTypes.Locality, person.City),
        //new Claim("company", person.Company),
        //new Claim("VIP", person.IsVIP),
        //new Claim(ClaimTypes.DateOfBirth, person.yearofBirth.ToString())
    };

    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});

//app.Map("/age", [Authorize(Policy = "AgeLimit")]() => "Age limit is passed");
//app.Map("/london", [Authorize(Policy = "OnlyForLondon")]() => "You are in London");
//app.Map("/microsoft", [Authorize(Policy = "OnlyForMicrosoft")]() => "You ar ein Microsoft");
app.Map("/adminroom", [Authorize(Policy = "ForAdmins")]()=>"You are in an admin room");
app.Map("/viproom", [Authorize(Policy = "OnlyForVIPS")]()=>"You are in a VIP room");

app.Map("/", [Authorize] (HttpContext context) =>
{
    var login = context.User.FindFirst(ClaimTypes.Name);
    var status = context.User.FindFirst("Status");
    //var city = context.User.FindFirst(ClaimTypes.Locality);
   //var company = context.User.FindFirst("company");
    //var isVip = context.User.FindFirst("VIP");
    //var age = context.User.FindFirst(ClaimTypes.DateOfBirth);
    return $"Name: {login?.Value}\nStatus: {status?.Value}";
});

app.Map("/logout", async (HttpContext context) => 
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Data was removed";
});

app.Run();
record class Person(string Email, string Password, string Status);
//record class Person(string Email, string Password, int yearofBirth, string City, string Company, string IsVIP);

public class AgeHandler : AuthorizationHandler<AgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
    {
        var yearClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
        if (yearClaim is not null)
        {
            if (int.TryParse(yearClaim.Value, out var year))
            {
                if ((DateTime.Now.Year - year) >= requirement.Age)
                    context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}

public class AgeRequirement : IAuthorizationRequirement
{
    protected internal int Age { get; set; }
    public AgeRequirement(int age) => Age = age;
}