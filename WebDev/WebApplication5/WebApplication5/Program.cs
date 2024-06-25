using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;

//using System.Text;

//var people = new List<Person>();
//{
//    new Person("tom@gmail.com", "12345");
//    new Person("bob@gmail.com", "11111");
//};

//var builder = WebApplication.CreateBuilder();

//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidIssuer = AuthOptions.ISSUER,
//        ValidateAudience = true,
//        ValidAudience = AuthOptions.AUDIENCE,
//        ValidateLifetime = true,
//        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
//        ValidateIssuerSigningKey = true,
//    };
//});

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapPost("/login", (Person logindata) => 
//{
//    Person? person = people.FirstOrDefault(p => p.Email == logindata.Email && p.Password == logindata.Password);
//    if (person is null) return Results.Unauthorized();

//    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
//    var jwt = new JwtSecurityToken(
//        issuer: AuthOptions.ISSUER,
//        audience: AuthOptions.AUDIENCE,
//        claims: claims,
//        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
//        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
//    var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

//    var responce = new
//    {
//        access_token = encodeJwt,
//        username = person.Email
//    };

//    return Results.Json(responce);
//});

//app.Map("/data", [Authorize]() => new { message = "We use Jwt auth"});
//app.Run();
//public class AuthOptions 
//{
//    public const string ISSUER = "MyAuthServer";
//    public const string AUDIENCE = "MyAuthClient";
//    const string KEY = "mysuper_secret123";
//    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
//        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
//}

//record class Person(string Email, string Password);
////////////////////
//var builder = WebApplication.CreateBuilder();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
//var app = builder.Build();

//app.UseAuthentication();
//app.MapGet("/login/{username}", async(HttpContext context) => 
//{
//    var username = "Sam";
//    var company = "Microsoft";
//    var phone = "1234567890";

//    var claims = new List<Claim>
//    {
//        new Claim (ClaimTypes.Name, username),
//        new Claim ("languages", "English"),
//        new Claim ("languages", "German"),
//        new Claim ("languages", "Spanish"),
//        new Claim ("company", company),
//        new Claim(ClaimTypes.MobilePhone, phone)
//    };

//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return Results.Redirect("/");
//});

//app.MapGet("/addage", async (HttpContext context) => 
//{
//    if(context.User.Identity is ClaimsIdentity claimsIdentity) 
//    {
//        claimsIdentity.AddClaim(new Claim ("age", "25"));
//        var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
//        await context.SignInAsync(claimPrincipal);
//    }
//});

//app.MapGet("/removephone", async (HttpContext context) => 
//{
//    if(context.User.Identity is ClaimsIdentity claimsIdentity) 
//    {
//        var phoneClaim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);

//        if (claimsIdentity.TryRemoveClaim(phoneClaim)) 
//        {
//            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//            await context.SignInAsync(claimsPrincipal);
//        }
//    }
//});

//app.MapGet("/logout", async(HttpContext context) => 
//{
//    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    return Results.Redirect("/");
//});

//app.Map("/", (HttpContext context) =>
//{
//    var username = context.User.FindFirst(ClaimTypes.Name);
//    var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//    var company = context.User.FindFirst("company");

//    var languages = context.User.FindAll("languages");

//    var res = "";
//    foreach (var l in languages) 
//    {
//        res = $"{res} {l.Value}";
//    }

//    return $"Name: {username?.Value}\nLanguages: {res}\nPhone: {phone?.Value}\nCompany: {company?.Value}";

//});

//app.Run();

var adminRole = new Role("admin");
var userRole = new Role("user");
var people = new List<Person>
{
    new Person("tom@gmail.com", "12345", adminRole),
    new Person("bob@gmail.com", "12345", userRole)
};

var builder = WebApplication.CreateBuilder();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
{
    options.LoginPath = "/Home/SignIn";
    options.AccessDeniedPath = "/accessdenied";
});
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/accessdenied", async (HttpContext context) => 
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access denied");
});

app.MapGet("/Home/SignIn", async (HttpContext context) => 
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
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Wrong credentials");
    string email = form["email"];
    string password = form["password"];

    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Name),
    };

    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});

app.Map("/admin", [Authorize(Roles = "admin")] () => "Admin Panel");
app.Map("/", [Authorize(Roles = "admin, user")] (HttpContext context) => 
{
    var login = context.User.FindFirst(ClaimsIdentity.DefaultNameClaimType);
    var role = context.User.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
    return $"Name: {login?.Value}\nRole: {role?.Value}";
});

app.MapGet("/logout", async (HttpContext context) => 
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    Results.Redirect("/");
});
app.Run();

class Person 
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public Person(string email, string password, Role role)
    {
        Email = email;
        Password = password;
        Role = role;
    }   
}

public class Role
{
    public string Name { get; set; }
    public Role(string name)
    {
        Name = name;
    }
}