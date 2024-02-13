using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/loja")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly ILojaRepository _lojaRepositorio;

        public LojaController(ILojaRepository lojaRepositorio)
        {
            _lojaRepositorio = lojaRepositorio;
        }

        /// <summary>
        /// Obter todas as Lojas
        /// </summary>
        /// <returns>Lista de Lojas</returns>
        /// <response code="200">Sucesso</response>
        [Route("get")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LojaModel>>> GetLojas()
        {
           List<LojaModel> lojas = await _lojaRepositorio.GetALL();
           return Ok(lojas);
        }

        /// <summary>
        /// Obter uma Loja e seus Produtos
        /// </summary>
        /// <param name="id">Identificador da Loja</param>
        /// <returns>Dados da Loja</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LojaModel>> GetLoja(int id)
        {
            try 
            { 
            LojaModel loja = await _lojaRepositorio.Get(id);
            return Ok(loja);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter Produtos da Loja
        /// </summary>
        /// <param name="LojaId">Identificador da Loja</param>
        /// <returns>Produtos da Loja</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{LojaId}/produtos")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ProdutoModel>>> GetProdutos(int LojaId)
        {
            try
            {
                List<ProdutoModel> Produtos = await _lojaRepositorio.GetProdutos(LojaId);
                return Ok(Produtos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar uma Loja
        /// </summary>
        /// <remarks>
        /// {
        /// "nome":"string",
        /// "endereço":"string",
        /// "telefone":"string"
        /// }
        /// </remarks>
        /// <param name="LojaModel">Dados da Loja</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("add")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LojaModel>> AddLoja([FromBody] LojaViewModel LojaModel)
        {
            try
            {
                LojaModel Loja = await _lojaRepositorio.Add(LojaModel);
                return Ok(Loja);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }

        /// <summary>
        /// Atualizar uma Loja
        /// </summary>
        /// <remarks>
        /// {
        /// "Nome":"string",
        /// "Endereço":"string",
        /// "Telefone":"string"
        /// }
        /// </remarks>
        /// <param name="id">Identificador da Loja</param>
        /// <param name="LojaModel">Dados da Loja</param>
        /// <returns>Dados da Loja</returns>
        /// <response code="400">Não encontrado ou Não Documentado.</response>
        /// <response code="200">Sucesso</response>
        [Route("/update/{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LojaModel>> UpdateLoja([FromBody] LojaViewModel LojaModel, int id)
        {
            try 
            { 
                await _lojaRepositorio.Update(LojaModel,id);
                return Ok(LojaModel);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar uma Loja
        /// </summary>
        /// <param name="id">Identificador da Loja</param>
        /// <returns>Nada</returns>
        /// <response code="400">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteLoja(int id)
        {
            try
            {
                await _lojaRepositorio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
