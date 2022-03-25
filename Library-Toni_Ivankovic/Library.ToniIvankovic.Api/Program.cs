using Library.ToniIvankovic.Contracts.Services;
using Library.ToniIvankovic.Data.Db.Repositories;
using Library.ToniIvankovic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB"), opt => opt.MigrationsAssembly("Library.ToniIvankovic.Data.Db"));
});
// Custom services
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<DbContext, ApplicationDbContext>();

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

app.Use(async (context, next) =>
{
    var request = context.Request;
    Console.WriteLine("Request User-Agent: " + request.Headers.UserAgent);
    await next(context);
});

app.MapControllers();

app.Run();
