using Domain.Interfaces.IDepartamento;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly InterfaceDepartamento _InterfaceDepartamento;
        private readonly IDepartamentoServico _IDepartamentoServico;

        public DepartamentoController(InterfaceDepartamento InterfaceDepartamento, IDepartamentoServico IDepartamentoServico)
        {
            _InterfaceDepartamento = InterfaceDepartamento;
            _IDepartamentoServico = IDepartamentoServico;
        }

        [HttpGet("/api/ListarDepartamentosUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDepartamentosUsuario(string emailUsuario)
        {
            return await _InterfaceDepartamento.ListarDepartamentosUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDepartamento")]
        [Produces("application/json")]
        public async Task<object> AdicionarDepartamento(Departamento departamento)
        {
            await _IDepartamentoServico.AdicionarDepartamento(departamento);

            return departamento;
        }

        [HttpPut("/api/AtualizarDepartamento")]
        [Produces("application/json")]
        public async Task<object> AtualizarDepartamento(Departamento departamento)
        {
            await _IDepartamentoServico.AtualizarDepartamento(departamento);

            return departamento;
        }

        [HttpGet("/api/ObterDepartamento")]
        [Produces("application/json")]
        public async Task<object> ObterDepartamento(int id)
        {
            return await _InterfaceDepartamento.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteDepartamento")]
        [Produces("application/json")]
        public async Task<object> DeleteDepartamento(int id)
        {
            try
            {
                var departamento = await _InterfaceDepartamento.GetEntityById(id);
                await _InterfaceDepartamento.Delete(departamento);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}
