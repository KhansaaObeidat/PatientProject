using Microsoft.EntityFrameworkCore;
using PatientProject.Data;
using PatientProject.Mappings;
using PatientProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddScoped<IPatientRepository, SQLPatientRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7285")  // Replace with your front-end URL
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();  // If needed, for cookies/auth
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
