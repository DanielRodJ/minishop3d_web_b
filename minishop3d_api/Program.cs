using Application;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infraestructure;
using Infraestructure.Auth;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Authentication;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

GoogleCredential credential;
var credentialPath = builder.Configuration["GoogleCloud:CredentialPath"];

if (!string.IsNullOrEmpty(credentialPath))
{
    var fullPath = Path.Combine(AppContext.BaseDirectory, credentialPath);
    credential = GoogleCredential.FromFile(fullPath);
}
else
{
    credential = GoogleCredential.GetApplicationDefault();
}

FirebaseApp.Create(new AppOptions() { Credential = credential });

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Firebase")
    .AddScheme<AuthenticationSchemeOptions, FirebaseAuthHandler>("Firebase", null);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

var origins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("DevPolicy", policy =>
    {
        policy.WithOrigins(origins!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseCors("DevPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();