using pcso_jcr_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using System.IdentityModel.Tokens;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//dotnet tool install --global dotnet-svcutil
//https://www.azuredevopslabs.com/labs/azuredevops/git/
//https://www.youtube.com/watch?v=qtYIpZX-s-k

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//options => builder.Configuration.Bind("JwtSettings", options))
//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//  options => builder.Configuration.Bind("CookieSettings", options));

//uthentication(options =>
//{
    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
    //var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT").GetSection("Key").Value);
    //var ValidIssuer = builder.Configuration.GetSection("JWT").GetSection("Issuer").Value;
    //var ValidAudience = builder.Configuration.GetSection("JWT").GetSection("Audience").Value;
    //var IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
    //o.SaveToken = true;
    //o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    //{
        //ValidateIssuerSigningKey = true,
        //ValidIssuer = ValidIssuer,
        //ValidAudience = ValidAudience,
        //IssuerSigningKey = IssuerSigningKey
    //};
//}
//);

//.GetSection("AppSettings")["Site"]

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://10.32.7.142", "http://localhost:4200", "http://localhost:57155", "http://localhost:58157", "http://localhost:7157",
                "http://localhost:44351"
                )
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);


app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
