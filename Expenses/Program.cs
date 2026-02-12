using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IExpensesRepo, ExpensesRepo>();
builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
    options.UseSqlite("Data Source=expenses.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ExpenseTrackerContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense API v1");
    c.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
