using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder();

var people = new List<Person>
{
    new Person("tom@gmail.com", "12345"),
    new Person("bob@gmail.com", "54321")
};

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => option.LoginPath = "/login");
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Map("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("index.html");
});

app.MapPost("/login", async (string? returnUrl, HttpContext context) => 
{
    var form = context.Request.Form;
    if(!form.ContainsKey("email") || !form.ContainsKey("password")) 
    {
        return Results.BadRequest("Email or password is invalid");
    }
    string email = form["email"];
    string password = form["password"];

    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);

    if (person is null) 
        return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookie");

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    return Results.Redirect(returnUrl??"/");
});

app.MapGet("/logout", async (HttpContext context) => 
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
});

app.Map("/", [Authorize] async (HttpContext context) => 
{
    await context.Response.WriteAsync("You are logged in!");
} );

app.Run();

record class Person(string Email, string Password);