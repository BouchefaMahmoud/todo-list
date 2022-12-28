using System.Reflection;
using Application.Services.Modules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using TodoListApi.Extensions;
using TodoListApi.Filters;

var builder = WebApplication.CreateBuilder(args);


//Referencer les services de l'assembly Application.Services
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModule());
    });


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddControllers(options => options.Filters.Add(new ApiExceptionFilterAttribute()));


builder.Services.ConfigureService(builder.Configuration);


builder.Services.ConfigureCors("CorsCong");

builder.Services.ConfigureAuthentication(builder.Configuration);

//DbContext
builder.Services.ConfigureContext(builder.Configuration);

//repositories
builder.Services.ConfigureContextServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.ConfigureSwagger();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection(); // Autorest/NSwag won't work if redirect are enabled     
}

app.UseRouting();
app.UseAuthentication(); // Attention Authentication before Authorization
app.UseAuthorization();
app.UseCors("CorsConf");


//app.ConfigureSwagger();

/*
using var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
migrationSvcScope.ServiceProvider.GetService<PrescriptionsContext>().Database.SetCommandTimeout(300);
migrationSvcScope.ServiceProvider.GetService<PrescriptionsContext>().Database.Migrate();
*/
app.Run();