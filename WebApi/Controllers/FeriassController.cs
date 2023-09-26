using Domain.Interfaces.IDepartamento;
using Domain.Interfaces.IFerias;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeriassController : ControllerBase
    {
        private readonly InterfaceFerias _InterfaceFerias;
        private readonly IFeriasServico _IFeriasServico;
        public FeriassController(InterfaceFerias InterfaceFerias, IFeriasServico IFeriasServico)
        {
            _InterfaceFerias = InterfaceFerias;
            _IFeriasServico = IFeriasServico;
        }

        [HttpGet("/api/ListarFeriassUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarFeriassUsuario(string emailUsuario)
        {
            return await _InterfaceFerias.ListarFeriassUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarFerias")]
        [Produces("application/json")]
        public async Task<object> AdicionarFerias(Ferias despesa)
        {
            await _IFeriasServico.AdicionarFerias(despesa);

            return despesa;

        }

        [HttpPut("/api/AtualizarFerias")]
        [Produces("application/json")]
        public async Task<object> AtualizarFerias(Ferias despesa)
        {
            await _IFeriasServico.AtualizarFerias(despesa);

            return despesa;

        }


        [HttpGet("/api/ObterFerias")]
        [Produces("application/json")]
        public async Task<object> ObterFerias(int id)
        {
            return await _InterfaceFerias.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteFerias")]
        [Produces("application/json")]
        public async Task<object> DeleteFerias(int id)
        {
            try
            {
                var departamento = await _InterfaceFerias.GetEntityById(id);
                await _InterfaceFerias.Delete(departamento);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _IFeriasServico.CarregaGraficos(emailUsuario);
        }


    }
}
