using System.Globalization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application;
using OnlineShop.Persistence;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddMvcOptions(options => 
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "The field is required.");
});

builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DefaultContext>();

builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = builder.Configuration["AuthenticationConfiguration:GoogleClientId"];
    options.ClientSecret = builder.Configuration["AuthenticationConfiguration:GoogleClientSecret"];
});

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DefaultContext>();
    context.Database.EnsureCreated();
    DbInitializer.InitializeCategories(context);
    DbInitializer.InitializeDishes(context);
    DbInitializer.InitializeRestaurants(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dish}/{action=Index}/{id?}");
app.MapControllers();
app.MapRazorPages();

app.Run();