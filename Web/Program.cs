using Autofac.Extensions.DependencyInjection;
using Autofac;
using Core.IoC;

var builder = WebApplication.CreateBuilder(args);


// Autofac START
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    CoreContainer.Bind(builder);
});
// Autofac END

/*
// start DI
builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
// mapper
builder.Services.AddScoped<ILandlordMapper, LandlordMapper>();
// end DI
*/



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
