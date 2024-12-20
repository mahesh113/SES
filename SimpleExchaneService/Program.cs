using SimpleExchangeService.Application;
using SimpleExchangeService.Application.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json",
        optional: true,
        reloadOnChange: true);

// Add services to the container
//builder.Services.AddScoped<IConversionService, ConversionService>();
builder.Services.AddHttpClient<IConversionService, ConversionService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
