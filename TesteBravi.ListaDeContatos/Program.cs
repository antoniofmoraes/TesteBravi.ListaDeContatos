using TesteBravi.ListaDeContatos.Data;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TesteBravi.ListaDeContatos.Controllers;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ListaDeContatosContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, contextLifetime: ServiceLifetime.Transient);
builder.Services.AddTransient<ListaDeContatosContext>();

builder.Services.AddScoped<IContatosRepository, ContatosRepository>();
builder.Services.AddScoped<IPessoasRepository, PessoasRepository>();
builder.Services.AddScoped<IRepositoryBase, RepositoryBase>();

builder.Services.AddScoped<GetContatosByPessoaIdUseCase>();
builder.Services.AddScoped<GetContatosUseCase>();
builder.Services.AddScoped<DeleteContatoUseCase>();
builder.Services.AddScoped<InsertContatoUseCase>();
builder.Services.AddScoped<UpdateContatoUseCase>();

builder.Services.AddScoped<GetPessoasUseCase>();
builder.Services.AddScoped<GetPessoaUseCase>();
builder.Services.AddScoped<DeletePessoaUseCase>();
builder.Services.AddScoped<InsertPessoaUseCase>();
builder.Services.AddScoped<UpdatePessoaUseCase>();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder =>
 builder.WithOrigins("http://127.0.0.1:5173", "http://localhost:8080")
 .AllowAnyHeader()
 .AllowCredentials()
 .AllowAnyMethod());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
