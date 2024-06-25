using Microsoft.EntityFrameworkCore;
using WebAppDataBase.Models;


var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb; Database = userstoredb; Trusted_Connection = true";
builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
