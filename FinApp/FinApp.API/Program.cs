using FinApp.API.Data;
using FinApp.API.Mappings;
using FinApp.API.Middlewares;
using FinApp.API.Repositories;
using FinApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FinAppConnectionString")));

builder.Services.AddScoped<IAgreementRepository, AgreementRepository>();
builder.Services.AddScoped<IFinancialStatementRepository, FinancialStatementRepository>();
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IRiskAnalysisRepository, RiskAnalysisRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
