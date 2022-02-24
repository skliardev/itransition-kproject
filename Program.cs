using Microsoft.EntityFrameworkCore;
using project.Domain;
using project.Domain.Entities;
using project.Domain.Entities.Review;
using project.Domain.Repositories.Abstract;
using project.Domain.Repositories.EntityFramework;
using project.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UptimeService>();

builder.Services.AddControllersWithViews();

builder.Configuration.Bind("CompanyConfig", new CompanyConfig());

builder.Services.AddTransient<IRepository<UserAccount>, EFUserAccounts>();
builder.Services.AddTransient<IRepository<UserReview>, EFUserReviews>();
builder.Services.AddTransient<IRepository<Comment>, EFComments>();
builder.Services.AddTransient<IRepository<Group>, EFGroups>();
builder.Services.AddTransient<IRepository<HashTag>, EFHashTags>();
builder.Services.AddTransient<IRepository<Image>, EFImages>();
builder.Services.AddTransient<IRepository<Like>, EFLikes>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString("remoteSql")
));

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
    opts.MapControllerRoute("default", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.Run();
