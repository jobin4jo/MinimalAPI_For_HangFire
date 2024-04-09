using Hangfire;
using MailKit;
using MinimalAPI_For_HangFire.MailService;
using MinimalAPI_For_HangFire.Models;
using MinimalAPI_For_HangFire.Recurring_Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddHangfire(configuration => configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseInMemoryStorage());

builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHangfireDashboard("");
//await app.StartAsync();

RecurringJob.AddOrUpdate<Recurring_jobs>(emailJob => emailJob.Pushmail(), "*/15 * * * * *");
app.UseAuthorization();

app.MapControllers();

app.Run();
