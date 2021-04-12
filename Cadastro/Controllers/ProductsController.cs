using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IClientViewModelService _clientViewModelService;
        private readonly IProductViewModelService _productViewModelService;

        public ProductsController(IClientViewModelService clientViewModelService, IProductViewModelService productViewModelService)
        {
            _clientViewModelService = clientViewModelService;
            _productViewModelService = productViewModelService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_clientViewModelService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["IdClient"] = new SelectList(_clientViewModelService.GetAll(), "Id", "Name");
            var viewModel = _productViewModelService.Get(id);

            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
