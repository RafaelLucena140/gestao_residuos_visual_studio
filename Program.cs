using AutoMapper;
using gestao_residuos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configuracao do DB
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(

    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Registro IServiceCollection

builder.Services.AddScoped<IColetaRepository, ColetaRepository>();
builder.Services.AddScoped<IColetaService, ColetaService>();

#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<ClienteModel, ClienteCreateViewModel>();
    c.CreateMap<ClienteCreateViewModel, ClienteModel>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

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
