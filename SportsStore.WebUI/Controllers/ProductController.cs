using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string category)
        {
            ProductsListViewModel model = new ProductsListViewModel();
            model.Products = _repository.Products.Where(p => p.Category == category).OrderBy(p => p.ProductId);
            model.CurrentCategory = category;
            return View(model);
        }
    }
}