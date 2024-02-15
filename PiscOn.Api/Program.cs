using PiscOn.Api.Classes.DI;
using PiscOn.Api.Classes.Infra;

var builder = WebApplication.CreateBuilder(args);

#region [ Add services to the container ]

builder.Services.RepositoriesDI();
builder.Services.ServicesDI();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region [ Configure the HTTP request pipeline ]

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbUpConfig.ExecuteScripts(app.Configuration);

#endregion

app.Run();
