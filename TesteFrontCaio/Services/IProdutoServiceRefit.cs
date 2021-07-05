using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFrontCaio.Models;

namespace TesteFrontCaio.Services
{
    public interface IProdutoServiceRefit
    {
        [Get("/api/produtos")]
        Task<List<ProdutoModel>> ObterTodosProdutos();

        [Get("/api/produtos/{id}")]
        Task<ProdutoModel> ObterProdutoPorId([AliasAs("id")] int id);

        [Post("/api/produtos")]
        Task<ProdutoModel> Adicionar([Body] ProdutoModel produto);

        [Put("/api/produtos/{id}")]
        Task<ProdutoModel> Alterar([AliasAs("id")] int id, [Body] ProdutoModel produto);

        [Delete("/api/produtos/{id}")]
        Task<ProdutoModel> Delete([AliasAs("id")] int id);
    }
}
