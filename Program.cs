using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SocialHubApi.Data;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o DbContext para usar o MySQL.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SocialHubDb"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SocialHubDb"))));

// Adicionar serviços de API e Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar os controladores para a aplicação.
builder.Services.AddControllers();

// Adicionar suporte para arquivos estáticos (para servir arquivos como imagens, CSS, JS, etc.)
builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
);

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adicionar o middleware para servir arquivos estáticos.
app.UseStaticFiles();  // Habilita a busca por arquivos estáticos na pasta wwwroot.

app.UseRouting();  // Assegura que o roteamento está habilitado.
app.MapControllers();  // Mapear controladores.

// Endpoint padrão.
app.MapGet("/", () => Results.Redirect("/swagger"));  // Redireciona para Swagger ou outra página de sua escolha.

app.Run();
