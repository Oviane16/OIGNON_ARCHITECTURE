using Microsoft.AspNetCore.Mvc;
using PRODUCT.BLL.Services.Interfaces;
using PRODUCT.BOL.Dto;
using PRODUCT.UI.Models.Product;

namespace PRODUCT.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> GetGridData(GridParamModel gridParamModel)
        {
            var gridData = await _productService.GetGridData(new GridParamDTO
            {
                Skip = gridParamModel.Start,
                Take = gridParamModel.Length,
                Draw = gridParamModel.Draw
            });
            return Json(
            gridData);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetById(id);
            return View(new EditProductModel
            {
                Id = product.Id,
                Matricule = product.Matricule,
                Name = product.Name,
                Slug = product.Slug
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(new ProductDTO
                {
                    Matricule = model.Matricule,
                    Name = model.Name,
                    Slug = model.Slug,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(new ProductDTO
                {
                    Matricule = model.Matricule,
                    Name = model.Name,
                    Slug = model.Slug
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
