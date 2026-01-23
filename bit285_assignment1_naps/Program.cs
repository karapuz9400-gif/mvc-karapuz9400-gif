var builder = WebApplication.CreateBuilder(args);

/* Install Services using the builder.Services methods
 */
// Add MVC services (controllers with views)
builder.Services.AddControllersWithViews();



var app = builder.Build();


/* Middleware in the HTTP Request Pipeline
 */
app.UseStaticFiles();

// Enable routing for controllers
app.UseRouting();



// Map default controller route to Naps/AccountInfo
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Naps}/{action=AccountInfo}/{id?}");

app.Run();
