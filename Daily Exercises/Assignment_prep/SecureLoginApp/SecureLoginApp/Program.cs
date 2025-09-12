


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();



using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureLoginApp.Data;
using SecureLoginApp.Models;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Force HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 443;
});

// Database Configuration with retry logic
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

// ASP.NET Core 8.0 Identity Configuration
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// Authentication and Authorization Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Error/AccessDenied";
});

// Data Protection - Use file system temporarily
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()))
    .SetApplicationName("SecureLoginApp");

// Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seed roles and admin user - WITH DATABASE CREATION LOGIC
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // Ensure database is created
        context.Database.EnsureCreated();

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Create roles
        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create admin user
        var adminUser = await userManager.FindByNameAsync("admin");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                FirstName = "Admin",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Create sample user
        var sampleUser = await userManager.FindByNameAsync("user1");
        if (sampleUser == null)
        {
            sampleUser = new ApplicationUser
            {
                UserName = "user1",
                Email = "user1@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            var result = await userManager.CreateAsync(sampleUser, "User@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(sampleUser, "User");
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");

        // If database doesn't exist, create it
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync();
    }
}

app.Run();







//using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SecureLoginApp.Data;
//using SecureLoginApp.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//// Force HTTPS
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//    options.HttpsPort = 443;
//});

//// Database Configuration
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

//// ASP.NET Core 8.0 Identity Configuration
//builder.Services.AddIdentityCore<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequiredLength = 8;
//})
//.AddRoles<IdentityRole>()
//.AddEntityFrameworkStores<ApplicationDbContext>()
//.AddSignInManager()
//.AddDefaultTokenProviders();

//// Authentication and Authorization Services
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//})
//.AddIdentityCookies();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Error/AccessDenied";
//});

//// Data Protection with Entity Framework Core
//builder.Services.AddDataProtection()
//    .PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()))
//    .SetApplicationName("SecureLoginApp");

//// Razor Pages (for Identity UI if needed)
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication(); // Add this - it was missing!
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

//// Seed roles and admin user
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

//        // Create roles
//        string[] roleNames = { "Admin", "User" };
//        foreach (var roleName in roleNames)
//        {
//            if (!await roleManager.RoleExistsAsync(roleName))
//            {
//                await roleManager.CreateAsync(new IdentityRole(roleName));
//            }
//        }

//        // Create admin user
//        var adminUser = await userManager.FindByNameAsync("admin");
//        if (adminUser == null)
//        {
//            adminUser = new ApplicationUser
//            {
//                UserName = "admin",
//                Email = "admin@example.com",
//                FirstName = "Admin",
//                LastName = "User"
//            };

//            var result = await userManager.CreateAsync(adminUser, "Admin@123");
//            if (result.Succeeded)
//            {
//                await userManager.AddToRoleAsync(adminUser, "Admin");
//            }
//        }

//        // Create sample user
//        var sampleUser = await userManager.FindByNameAsync("user1");
//        if (sampleUser == null)
//        {
//            sampleUser = new ApplicationUser
//            {
//                UserName = "user1",
//                Email = "user1@example.com",
//                FirstName = "John",
//                LastName = "Doe"
//            };

//            var result = await userManager.CreateAsync(sampleUser, "User@123");
//            if (result.Succeeded)
//            {
//                await userManager.AddToRoleAsync(sampleUser, "User");
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}

//app.Run();







//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SecureLoginApp.Data;
//using SecureLoginApp.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Force HTTPS
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//    options.HttpsPort = 443;
//});

//// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequiredLength = 8;
//})
//.AddRoles<IdentityRole>()
//.AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

//// Data Protection
//builder.Services.AddDataProtection()
//    .PersistKeysToDbContext<ApplicationDbContext>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

//// Seed roles and admin user
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//    // Create roles
//    string[] roleNames = { "Admin", "User" };
//    foreach (var roleName in roleNames)
//    {
//        if (!await roleManager.RoleExistsAsync(roleName))
//        {
//            await roleManager.CreateAsync(new IdentityRole(roleName));
//        }
//    }

//    // Create admin user
//    var adminUser = await userManager.FindByNameAsync("admin");
//    if (adminUser == null)
//    {
//        adminUser = new ApplicationUser
//        {
//            UserName = "admin",
//            Email = "admin@example.com",
//            FirstName = "Admin",
//            LastName = "User"
//        };

//        var result = await userManager.CreateAsync(adminUser, "Admin@123");
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(adminUser, "Admin");
//        }
//    }

//    // Create sample user
//    var sampleUser = await userManager.FindByNameAsync("user1");
//    if (sampleUser == null)
//    {
//        sampleUser = new ApplicationUser
//        {
//            UserName = "user1",
//            Email = "user1@example.com",
//            FirstName = "John",
//            LastName = "Doe"
//        };

//        var result = await userManager.CreateAsync(sampleUser, "User@123");
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(sampleUser, "User");
//        }
//    }
//}

//app.Run();


//using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SecureLoginApp.Data;
//using SecureLoginApp.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Force HTTPS
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//    options.HttpsPort = 443;
//});

//// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// NEW: ASP.NET Core 8.0 Identity Configuration
//builder.Services.AddIdentityCore<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequiredLength = 8;
//})
//.AddRoles<IdentityRole>()
//.AddEntityFrameworkStores<ApplicationDbContext>()
//.AddSignInManager()
//.AddDefaultTokenProviders();

//// Add authentication and authorization services
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//})
//.AddIdentityCookies();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Error/AccessDenied";
//});

//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

//// Data Protection
//builder.Services.AddDataProtection()
//    .PersistKeysToDbContext<ApplicationDbContext>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

//// Seed roles and admin user
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//    // Create roles
//    string[] roleNames = { "Admin", "User" };
//    foreach (var roleName in roleNames)
//    {
//        if (!await roleManager.RoleExistsAsync(roleName))
//        {
//            await roleManager.CreateAsync(new IdentityRole(roleName));
//        }
//    }

//    // Create admin user
//    var adminUser = await userManager.FindByNameAsync("admin");
//    if (adminUser == null)
//    {
//        adminUser = new ApplicationUser
//        {
//            UserName = "admin",
//            Email = "admin@example.com",
//            FirstName = "Admin",
//            LastName = "User"
//        };

//        var result = await userManager.CreateAsync(adminUser, "Admin@123");
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(adminUser, "Admin");
//        }
//    }

//    // Create sample user
//    var sampleUser = await userManager.FindByNameAsync("user1");
//    if (sampleUser == null)
//    {
//        sampleUser = new ApplicationUser
//        {
//            UserName = "user1",
//            Email = "user1@example.com",
//            FirstName = "John",
//            LastName = "Doe"
//        };

//        var result = await userManager.CreateAsync(sampleUser, "User@123");
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(sampleUser, "User");
//        }
//    }
//}

//app.Run();