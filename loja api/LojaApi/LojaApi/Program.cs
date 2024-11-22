using LojaApi.Repositories;
using LojaApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080");
                      });
});

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

//Realiza a leitura da conexão com o banco
builder.Services.AddSingleton<produtosRepository>(provider => new produtosRepository(connection));
builder.Services.AddSingleton<usuariosRepository>(provider => new usuariosRepository(connection));
builder.Services.AddSingleton<carrinhoRepository>(provider => new carrinhoRepository(connection));

builder.Services.AddScoped<pedidosRepository>(provider =>
{
    var carrinhoRepository = provider.GetRequiredService<carrinhoRepository>();
    return new pedidosRepository(connection, carrinhoRepository);
});
//Swagger Parte 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

//Swagger Parte 2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud Lojas V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
