using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Identity.Data;
using Web.Data;
using Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.AddMiddlewares();
