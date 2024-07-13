using MemoryCache.Data;
using MemoryCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryCache.Controllers
{
    public class ProductController : Controller
    {
        private readonly AplicationDB dbContext;

        public ProductController(AplicationDB DbContext)
        {
            dbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product viewModel)
        {
            var product = new Product
            {
                Name = viewModel.Name,
                Price = viewModel.Price
            };

            await dbContext.products.AddAsync(product);
            await dbContext.SaveChangesAsync();


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var product =  await dbContext.products.ToListAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await dbContext.products.FindAsync(Id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Product viewModel)
        {
            var product = await dbContext.products.FindAsync(viewModel.Id);

            if (product is not null)
            {
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product viewModel)
        {
            var product = await dbContext.products.FindAsync(viewModel.Id);

            if (product != null)
            {
                dbContext.products.Remove(product);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
