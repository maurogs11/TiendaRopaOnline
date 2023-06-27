using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaRopaOnline.Business.Business;
using TiendaRopaOnline.DataAccess.DataContext;
using TiendaRopaOnline.Models;
using TiendaRopaOnline.Web.Models;

namespace TiendaRopaOnline.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness business)
        {
            _productBusiness = business;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> products = await GetProducts();

            return products != null ?
                        View(products.ToList()) :
                        Problem("Entity set 'TiendaOnlineContext.Products'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            List<ProductViewModel> products = await GetProducts();

            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private async Task<List<ProductViewModel>> GetProducts() {
            IQueryable<Product> query = await _productBusiness.FindAll();

            List<ProductViewModel> products = query.Select(
                p => new ProductViewModel()
                {
                    Id = p.Id,
                    Size = p.Size,
                    Color = p.Color,
                    Price = p.Price,
                    Description = p.Description
                }
            ).ToList();
            return products;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Size,Color,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productBusiness.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            List<ProductViewModel> products = await GetProducts();

            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Size,Color,Price,Description")] Product product)
        {
            List<ProductViewModel> products = await GetProducts();
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productBusiness.Edit(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!products.Any(p => p.Id == product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            List<ProductViewModel> products = await GetProducts();
            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            List<ProductViewModel> products = await GetProducts();

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                await _productBusiness.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

