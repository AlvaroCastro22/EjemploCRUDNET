using Microsoft.AspNetCore.Mvc;
using WebAppBD.Datos;
using WebAppBD.Models;

namespace WebAppBD.Controllers
{
    public class CategoriaController : Controller
    {

        public readonly ApplicationDbContext objcat;

        public CategoriaController(ApplicationDbContext dbContext)
        {
            objcat = dbContext;
        }
        public IActionResult Index()
        {
            List<Categoria> list = objcat.Categoria.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult RegistrarCategoria()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                objcat.Categoria.Add(categoria);
                objcat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id==null)
                { 
                return View();
            }
            var categoria = objcat.Categoria.FirstOrDefault(c=>c.Categoria_Id==id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria) {
            if (ModelState.IsValid) { 
                objcat.Categoria.Update(categoria);
                objcat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
            
        }
        [HttpGet]
        public IActionResult Delete(int? id) {
            var categoria = objcat.Categoria.FirstOrDefault(cat=>cat.Categoria_Id==id);
            objcat.Categoria.Remove(categoria);
            objcat.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
