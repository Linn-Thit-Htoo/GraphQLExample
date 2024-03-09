using GraphQLExample;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BlogQuery>();


var app = builder.Build();
app.MapGraphQL("/");

app.UseHttpsRedirection();

app.Run();
