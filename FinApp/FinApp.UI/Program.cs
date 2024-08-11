using FinApp.UI.Models.DTO;
using FinApp.UI.Services;
using FinApp.UI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBaseService<PartnerDto>, PartnerService>();
builder.Services.AddScoped<IBaseService<SubjectDto>, SubjectService>();
builder.Services.AddScoped<IAgreementService, AgreementService>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddHttpClient<PartnerService>();
builder.Services.AddHttpClient<SubjectService>();
builder.Services.AddHttpClient<AgreementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
