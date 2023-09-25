using Domain.Interfaces.Generics;
using Domain.Interfaces.IDepartamento;
using Domain.Interfaces.IFerias;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IFuncionarioFinanceiro;
using Domain.Interfaces.IUsuarioFuncionarioFinanceiro;
using Domain.Servicos;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();



// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceDepartamento, RepositorioDepartamento>();
builder.Services.AddSingleton<InterfaceFerias, RepositorioFerias>();
builder.Services.AddSingleton<InterfaceFuncionarioFinanceiro, RepositorioFuncionarioFinanceiro>();
builder.Services.AddSingleton<InterfaceUsuarioFuncionarioFinanceiro, RepositorioUsuarioFuncionarioFinanceiro>();


// SERVIÇO DOMINIO
builder.Services.AddSingleton<IDepartamentoServico, DepartamentoServico>();
builder.Services.AddSingleton<IFeriasServico, FeriasServico>();
builder.Services.AddSingleton<IFuncionarioFinanceiroServico, FuncionarioFinanceiroServico>();
builder.Services.AddSingleton<IUsuarioFuncionarioFinanceiroServico, UsuarioFuncionarioFinanceiroServico>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var devClient = "http://localhost:4200";

app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));


app.UseHttpsRedirection();

//New
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
