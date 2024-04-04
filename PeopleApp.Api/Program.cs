using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PeopleApp.Api.Attributes;
using PeopleApp.Api.Data;
using PeopleApp.Api.Data.DefaultData;
using PeopleApp.Api.Services;
using PeopleApp.Api.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PeopleConnection");
builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(connectionString);    
    });
//var section = builder.Configuration.GetSection("ApiKeyConfiguration");
//var apiKey = builder.Configuration.GetSection("ApiKey").Value;
//var config = new ApiKeyConfiguration { ApiKey = "test" };
//builder.Services.Configure<ApiKeyConfiguration>(section);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddControllers();
        //.AddJsonOptions(
        //    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        //);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
SeedData.SeedDatabase(app);
app.Run();
