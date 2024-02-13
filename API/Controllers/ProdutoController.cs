using API.Models;
using API.Repositórios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;

namespace API.Controllers
{
    [Route("/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepositorio;
        public ProdutoController(IProdutoRepository produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;

        }

        /// <summary>
        /// Obter todos os Produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        /// <response code="200">Sucesso</response>
        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> GetProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.GetALL();
            return Ok(produtos);
        }

        /// <summary>
        /// Obter um Produto
        /// </summary>
        /// <param name="id">Identificador do Produto</param>
        /// <returns>Dados do Produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProdutoModel>> GetProduto(int id)
        {
            try
            {
                ProdutoModel produto = await _produtoRepositorio.Get(id);
                return Ok(produto);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter Produto x Desconto do Cliente
        /// </summary>
        /// <param name="ProdutoId">Identificador do Produto</param>
        /// <param name="UsuarioId">Identificador do Usuário</param>
        /// <returns>Dados do Produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("get/{ProdutoId}/{UsuarioId}")]
        [HttpGet]
        public async Task<ActionResult<ProdutoModel>> GetProdutoComDesconto(int ProdutoId,int UsuarioId)
        {
            try
            {
                DescontoModel Desconto = await _produtoRepositorio.GetDesconto(UsuarioId);
                ProdutoModel Produto = await _produtoRepositorio.Get(ProdutoId);
                Produto.Preço = Produto.Preço - (Produto.Preço * Desconto.Taxa);
                return Ok(Produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar um Produto
        /// </summary>
        /// <remarks>
        /// {
        /// "nome":"string",
        /// "preço":"int",
        /// "estoque":"int",
        /// "lojaid":"int"
        /// }
        /// </remarks>
        /// <param name="ProdutoModel">Dados do Produto</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Não encontrado ou Não Documentado</response>
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> AddProduto([FromBody] ProdutoViewModel ProdutoModel)
        {
            try
            {
                var Produto = await _produtoRepositorio.Add(ProdutoModel);
                return Ok(Produto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um Produto
        /// </summary>
        /// <remarks>
        /// {
        /// "nome":"string",
        /// "preço":"int",
        /// "estoque":"int",
        /// "lojaid":"int"
        /// }
        /// </remarks>
        /// <param name="id">Identificador do Produto</param>
        /// <param name="ProdutoModel">Dados do Produto</param>
        /// <returns>Dados do Produto</returns>
        /// <response code="400">Não encontrado ou Não Documentado.</response>
        /// <response code="200">Sucesso</response>
        [Route("update/{id}")]
        [HttpPut]
        public async Task<ActionResult<ProdutoViewModel>> UpdateProduto([FromBody] ProdutoViewModel ProdutoModel, int id)
        {
            try
            {
                await _produtoRepositorio.Update(ProdutoModel,id);
                return Ok(ProdutoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar um Produto
        /// </summary>
        /// <param name="id">Identificador do Produto</param>
        /// <returns>Nada</returns>
        /// <response code="400">Não encontrado</response>
        /// <response code="200">Sucesso</response>
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoRepositorio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}