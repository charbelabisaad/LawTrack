using LawTrack.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders; 

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// ===============================
// 🔐 AUTHENTICATION (THIS IS REQUIRED)
// ===============================
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
	options.LoginPath = "/Index";     // 👈 LOGIN PAGE
	options.LogoutPath = "/LogOut";
	options.AccessDeniedPath = "/Index";
	options.ExpireTimeSpan = TimeSpan.FromHours(8);
});

builder.Services.Configure<FormOptions>(options =>
{
	options.ValueCountLimit = int.MaxValue;          // Max number of form keys
	options.KeyLengthLimit = int.MaxValue;           // Max length of a key
	options.ValueLengthLimit = int.MaxValue;         // Max length of a value
	options.MultipartHeadersLengthLimit = int.MaxValue;
	options.MultipartBodyLengthLimit = long.MaxValue; // Max file upload size
	options.MemoryBufferThreshold = int.MaxValue;

});
 
builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.Limits.MaxRequestBodySize = long.MaxValue;
});

// ✅ Add Session BEFORE builder.Build()
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // session lifetime
	options.Cookie.HttpOnly = true; // prevent JavaScript access
	options.Cookie.IsEssential = true; // required for GDPR compliance
});

builder.Services.AddDbContext<LawTrackDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LawTrackConnection")));
 
var app = builder.Build();

// Configure the HTTP request pipeline.65	a
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


//var imagesRoot = builder.Configuration["StaticFiles:ImagesRoot"]
//	?? throw new InvalidOperationException(
//		"StaticFiles:ImagesRoot is not configured.");

//app.UseStaticFiles(new StaticFileOptions
//{
//	FileProvider = new PhysicalFileProvider(imagesRoot),
//	RequestPath = ""
//});

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LogIn}/{action=Index}/{id?}");

app.Run();
