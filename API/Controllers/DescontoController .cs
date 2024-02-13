using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("/desconto")]
    [ApiController]
    public class DescontoController : ControllerBase
    {
        private readonly IDescontoRepository _descontoRepositorio;
        public DescontoController(IDescontoRepository descontoRepositorio)
        {
            _descontoRepositorio = descontoRepositorio;

        }

        /// <summary>
        /// Obter todos os Descontos
        /// </summary>
        /// <returns>Lista de Descontos</returns>
        /// <response code="200">Sucesso</response>
        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<List<DescontoModel>>> GetDescontos()
        {
            List<DescontoModel> descontos = await _descontoRepositorio.GetALL();
            return Ok(descontos);
        }

        /// <summary>
        /// Obter um Desconto
        /// </summary>
        /// <param name="id">Identificador do Desconto</param>
        /// <returns>Dados do Desconto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{id}")]
        [HttpGet]
        public async Task<ActionResult<DescontoModel>> GetDesconto(int id)
        {
            try
            {
                DescontoModel desconto = await _descontoRepositorio.Get(id);
                return Ok(desconto);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar um Desconto
        /// </summary>
        /// <remarks>
        /// {
        /// "nome":"string",
        /// "taxa":"int",
        /// "produtoid":"int"
        /// "usuarioid":"int"
        /// }
        /// </remarks>
        /// <param name="DescontoModel">Dados do Desconto</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<DescontoModel>> AddDesconto([FromBody] DescontoViewModel DescontoModel)
        {
            try
            {
                DescontoModel Desconto = await _descontoRepositorio.Add(DescontoModel);
                return Ok(Desconto);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Atualizar um Desconto
        /// </summary>
        /// <remarks>
        /// {
        /// "nome":"string",
        /// "taxa":"int",
        /// "produtoid":"int"
        /// "usuarioid":"int"
        /// }
        /// </remarks>
        /// <param name="id">Identificador do Desconto</param>
        /// <param name="DescontoModel">Dados do Desconto</param>
        /// <returns>Dados do Desconto</returns>
        /// <response code="400">Não encontrado ou Não Documentado.</response>
        /// <response code="200">Sucesso</response>
        [Route("update/{id}")]
        [HttpPut]
        public async Task<ActionResult<DescontoViewModel>> UpdateDesconto([FromBody] DescontoViewModel DescontoModel, int id)
        {
            try
            {
                await _descontoRepositorio.Update(DescontoModel,id);
                return Ok(DescontoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar um Desconto
        /// </summary>
        /// <param name="id">Identificador do Desconto</param>
        /// <returns>Nada</returns>
        /// <response code="400">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteDesconto(int id)
        {
            try
            {
                await _descontoRepositorio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}