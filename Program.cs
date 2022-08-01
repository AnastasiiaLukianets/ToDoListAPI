global using ToDoListAPI.Data;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// We are using AddScoped() method because we want the instance to be alive
// and available for the entire scope of the given HTTP request.
builder.Services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();
builder.Services.AddScoped<ITaskToDoService, TaskToDoService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Adds

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
