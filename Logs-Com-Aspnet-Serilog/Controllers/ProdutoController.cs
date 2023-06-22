using ApiExec.DataContext;
using ApiExec.DTO;
using ApiExec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Serilog;
using System.Text.Json;

namespace ApiExec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Context _context = null!;
        private readonly Serilog.ILogger _logger;
        public ProdutoController([FromServices] Context context)
        {
            _context = context;
           _logger = Log.ForContext<ProdutoController>();
        }

        [HttpPost("AdcionarProduto")]
        public async Task<IActionResult> Put([FromBody] ProdutoEstoque produto)
        {
            var json = JsonSerializer.Serialize(produto);

            if(produto is not null)
            {
               Produto p = new Produto();
                p.Preco = produto.Preco;
                p.Nome = produto.Nome;
                p.Descricao = produto.Descricao;
                p.DataValidade = produto.DataValidade;
                p.DataFrabricacao = produto.DataFrabricacao;

                Estoque e = new Estoque();
                e.Quantidade = produto.Quantidade;
                e.Produto = p;


                await _context.AddRangeAsync(p, e);


                await _context.SaveChangesAsync();

                _logger.ForContext("Payload", json).Information("Adcionando produto");

                return Ok(new {Message ="Produto adcionado com sucesso"});
            }

            return BadRequest(new { Erro = "Erro ao adcionar produto" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = _context.Produtos.Select(e => new ProdutoEstoque
            {
                Nome = e.Nome,
                Descricao = e.Descricao,
                Preco = e.Preco,
                DataFrabricacao = e.DataFrabricacao,
                DataValidade = e.DataValidade,
                Quantidade = e.Estoque.Quantidade
            })
            .ToList();



            if (!produtos.Any())
               return NotFound();

            _logger.Information("EndPoint GetAll consulta");
          
            return Ok(produtos);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var produtos = _context.Produtos
                .Where(p => p.Id.Equals(Id))
                .Select(p => new ProdutoEstoque
            {
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                DataFrabricacao = p.DataFrabricacao,
                DataValidade = p.DataValidade,
                Quantidade = p.Estoque.Quantidade
            });

            if (!produtos.Any()) 
                return NotFound();

            Serilog.Log.Information("EndPoint GetAll");

            return Ok(produtos);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var produto = await _context.Produtos
                .SingleOrDefaultAsync(p => p.Id.Equals(Id));

            if (produto != null) {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            return NotFound();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] ProdutoEstoque prodEstoque)
        {
            var produtoEstoque = await _context.Produtos.Include(e => e.Estoque).SingleOrDefaultAsync(pe => pe.Id == Id);

            if(produtoEstoque != null)
            {
                produtoEstoque.Preco =Convert.ToDecimal(prodEstoque.Preco);
                produtoEstoque.Nome = prodEstoque.Nome;
                produtoEstoque.Descricao = prodEstoque.Descricao;
                produtoEstoque.DataFrabricacao = prodEstoque.DataFrabricacao;
                produtoEstoque.DataValidade = prodEstoque.DataValidade;
                produtoEstoque.Estoque.Quantidade = Convert.ToInt32(prodEstoque.Quantidade);

                _context.Entry(produtoEstoque).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(new { Update = "Atualizado com sucesso" });
            }

            return NotFound();
        }
    }
}
