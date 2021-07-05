using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFrontCaio.Models;
using TesteFrontCaio.Services;

namespace TesteFrontCaio.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoServiceRefit _produtoServiceRefit;

        public ProdutoController(IProdutoServiceRefit produtoServiceRefit)
        {
            _produtoServiceRefit = produtoServiceRefit;
        }

        public async Task<IActionResult> Index()
        {
            List<ProdutoModel> produtos = await _produtoServiceRefit.ObterTodosProdutos();

            return View(produtos);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ProdutoModel produto = await _produtoServiceRefit.ObterProdutoPorId(id);

            return View(produto);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produtoServiceRefit.Delete(id);
                TempData["MensagemSucesso"] = "Produto deletado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar produto, detalhe: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoModel produto)
        {
            try
            {
                await _produtoServiceRefit.Adicionar(produto);
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar produto, detalhe: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProdutoModel produto)
        {
            try
            {
                await _produtoServiceRefit.Alterar(produto.Id, produto);
                TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao alterar produto, detalhe: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
