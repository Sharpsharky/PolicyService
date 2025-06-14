using Microsoft.EntityFrameworkCore;
using PolicyService.Application.Commands;
using PolicyService.Domain.Interfaces;
using PolicyService.Infrastructure.Persistence;
using PolicyService.Infrastructure.Rating;
using PolicyService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(CreatePolicyCommand).Assembly
    ));

builder.Services.AddDbContext<PolicyDbContext>(options =>
    options.UseSqlite("Data Source=policies.db"));

builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddSingleton<IRatingEngine, TenPercentRatingEngine>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
