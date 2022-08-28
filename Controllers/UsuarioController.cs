using Microsoft.AspNetCore.Mvc;
using Projeto_Confitec.DataContextInterface;
using Projeto_Confitec.Models;

namespace Projeto_Confitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositoryDataContext _repo;
        public UsuarioController(IRepositoryDataContext repository)
        {
            this._repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _repo.GetTodosUsuariosAsync();
                return Ok(result);

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> GetByAlunoId(int UsuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioPorId(UsuarioId);
                return Ok(result);

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _repo.Add(usuario);

                if (await _repo.SalvarAlteracoesAsync())
                {
                    var id = 1;
                    usuario.IdUsuario = id++;
                    return Ok(usuario);
                }


            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> put(int usuarioId, Usuario model)
        {
            try
            {
                var user = await _repo.GetUsuarioPorId(usuarioId);

                if (user == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SalvarAlteracoesAsync())
                {
                    var id = 1;
                    model.IdUsuario = id++;
                    return Ok(model);
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> delete(int usuarioId)
        {
            try
            {
                var user = await _repo.GetUsuarioPorId(usuarioId);

                if (user == null) return NotFound();

                _repo.Delete(user);

                if (await _repo.SalvarAlteracoesAsync())
                {
                    return Ok("Deletado com sucesso!");
                }


            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }
    }
}
