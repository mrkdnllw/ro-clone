using Microsoft.OpenApi.Models;
using ROCloneAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// pwede sad diay declarative :O

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Define the CharacterMonster endpoint
    c.SwaggerDoc("charactermonster", new OpenApiInfo { Title = "CharacterMonster API", Version = "v1" });
    c.MapType<CharacterMonster>(() => new OpenApiSchema { Type = "object" }); // Map the CharacterMonster model
});

builder.Services.AddScoped<Db1Context>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
