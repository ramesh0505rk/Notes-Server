using Microsoft.AspNetCore.Authentication.JwtBearer;
using NotesServer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://dev-42709845.okta.com/oauth2/default";
        options.Audience = "api://default";
    });

builder.Services.AddSingleton<DbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
