using Domain.Interfaces.IFerias;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeriasController : ControllerBase
    {
        private readonly InterfaceFerias _InterfaceFerias;
        private readonly IFeriasServico _IFeriasServico;
        public FeriasController(InterfaceFerias InterfaceFerias, IFeriasServico IFeriasServico)
        {
            _InterfaceFerias = InterfaceFerias;
            _IFeriasServico = IFeriasServico;
        }

        [HttpGet("/api/ListarFeriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarFeriasUsuario(string emailUsuario)
        {
            return await _InterfaceFerias.ListarFeriasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarFerias")]
        [Produces("application/json")]
        public async Task<object> AdicionarFerias(FeriasFuncionarioViewModel ferias)
        {
            await _IFeriasServico.AdicionarFerias(ferias);

            return ferias;
        }

        [HttpPut("/api/AtualizarFerias")]
        [Produces("application/json")]
        public async Task<object> AtualizarFerias(FeriasFuncionarioViewModel ferias)
        {
            await _IFeriasServico.AtualizarFerias(ferias);

            return ferias;
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
