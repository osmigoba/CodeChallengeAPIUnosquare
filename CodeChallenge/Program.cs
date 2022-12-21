
using CodeChallenge.Api.Base;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Interfaces;
using CodeChallenge.Core.Models;
using CodeChallenge.Core.Services.Implementation;
using CodeChallenge.Core.Services.Interfaces;
using CodeChallenge.Core.Validators;
using CodeChallenge.Infrastructure.Base;
using CodeChallenge.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "EnableCors";
// Add services to the container.
builder.Services.AddDbContext<CodeChallengeContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddControllers(
    options => options.Filters.Add(new CustomExceptionFilter()))
    // Avoid Circular Reference
    .AddJsonOptions(
        opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidationFilter>();
}).ConfigureApiBehaviorOptions(fv => fv.SuppressModelStateInvalidFilter = true);
//Validators registered
builder.Services.AddTransient<IValidator<ProductDTO>, ValidatorProductDTO>();

// Services
builder.Services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();


app.MapControllers();

app.Run();

