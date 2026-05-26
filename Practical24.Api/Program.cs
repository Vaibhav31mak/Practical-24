var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(ConfigureDbContext);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<EmployeeProfile>());

void ConfigureDbContext(DbContextOptionsBuilder options)
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}

var app = builder.Build();

// Seeded the database with initial data for testing and development purposes.
// Kindly visit the DatabaseSeeder class to see the seeded data and modify it as
// needed for testing scenarios.
await SeedDatabaseAsync(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task SeedDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
    await seeder.SeedAsync();
}
