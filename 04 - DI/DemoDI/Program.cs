using DemoDI.Cases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigureServices(builder.Services);

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


void ConfigureServices(IServiceCollection services)
{
    #region Lifecycle

    services.AddTransient<IOperacaoTransient, Operacao>();
    services.AddScoped<IOperacaoScoped, Operacao>();
    services.AddSingleton<IOperacaoSingleton, Operacao>();
    services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
    services.AddTransient<OperacaoService>();

    #endregion

    #region VidaReal

    services.AddScoped<IClienteRepository, ClienteRepository>();
    services.AddScoped<IClienteServices, ClienteServices>();

    #endregion

    #region Generics

    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    #endregion

    #region MultiplasClasses

    services.AddTransient<ServiceA>();
    services.AddTransient<ServiceB>();
    services.AddTransient<ServiceC>();
    services.AddTransient<Func<string, IService>>(serviceProvider => key =>
    {
        switch (key)
        {
            case "A":
                return serviceProvider.GetService<ServiceA>();
            case "B":
                return serviceProvider.GetService<ServiceB>();
            case "C":
                return serviceProvider.GetService<ServiceC>();
            default:
                return null;
        }
    });

    #endregion

    // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}