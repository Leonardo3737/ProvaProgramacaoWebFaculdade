using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProvaWeb.Data;
using ProvaWeb.Models;

namespace ProvaWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProvaWebContext _context;
        public ProdutoController(ProvaWebContext context) 
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public ActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public ActionResult Cadastrar()
        {
            return View(new Produto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Produtos.Add(produto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(produto);
                }
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Produto produto)
        {
            if(id != produto.Id)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Produtos.Update(produto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(produto);
                }
                
            }
            catch
            {
                return View(produto);
            }
        }

        public ActionResult Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id, IFormCollection collection)
        {
            try
            {
                var produto = _context.Produtos.Find(id);
                if (produto == null)
                {
                    return NotFound();
                }
                _context.Remove(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
