using project.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UptimeService>();

builder.Services.AddControllersWithViews();

builder.Configuration.Bind("CompanyConfig", new CompanyConfig());

var app = builder.Build();

// Banned windows users how example
//app.UseMiddleware<ShortCircuitMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(opts =>
{
    opts.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
