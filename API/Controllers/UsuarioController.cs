using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        public UsuarioController(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }

        /// <summary>
        /// Obter todos os Usuários
        /// </summary>
        /// <returns>Lista de Usuários</returns>
        /// <response code="200">Sucesso</response>
        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.GetALL();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obter um Usuário e seus Descontos 
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Dados do Usuário</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{id}")]
        [HttpGet]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(int id)
        {
            try 
            {   
                UsuarioModel usuario = await _usuarioRepositorio.Get(id);
                return Ok(usuario); 
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Obter Descontos do Usuário
        /// </summary>
        /// <param name="UsuarioId">Identificador do Usuário</param>
        /// <returns>Descontos do Usuário</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{UsuarioId}/descontos")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DescontoModel>>> GetDescontos(int UsuarioId)
        {
            try
            {
                List<DescontoModel> Descontos = await _usuarioRepositorio.GetDescontos(UsuarioId);
                return Ok(Descontos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar um Usuário
        /// </summary>
        /// <remarks>
        /// {
        /// "Nome":"string",
        /// "Email":"string",
        /// "Telefone":"string"
        /// }
        /// </remarks>
        /// <param name="UsuarioModel">Dados do Usuário</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AddUsuario([FromBody] UsuarioViewModel UsuarioModel)
        {
            try
            {
                var Usuario = await _usuarioRepositorio.Add(UsuarioModel);
                return Ok(Usuario);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um Usuário
        /// </summary>
        /// <remarks>
        /// {
        /// "Nome":"string",
        /// "Email":"string",
        /// "Telefone":"string"
        /// }
        /// </remarks>
        /// <param name="id">Identificador do Usuário</param>
        /// <param name="UsuarioModel">Dados do Usuário</param>
        /// <returns>Dados do Usuário</returns>
        /// <response code="400">Não encontrado ou Não Documentado.</response>
        /// <response code="200">Sucesso</response>
        [Route("update/{id}")]
        [HttpPut]
        public async Task<ActionResult<UsuarioViewModel>> UpdateUsuario([FromBody] UsuarioViewModel UsuarioModel, int id)
        {
            try
            {
                await _usuarioRepositorio.Update(UsuarioModel, id);
                return Ok(UsuarioModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar um Usuário
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Nada</returns>
        /// <response code="400">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            try
            {
                await _usuarioRepositorio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
