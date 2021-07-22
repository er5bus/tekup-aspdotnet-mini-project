using TekupMiniProject.Models;
using TekupMiniProject.Models.Repositories;
using TekupMiniProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TekupMiniProject.Controllers
{
    public class ProductController : Controller
    {

        public PictureRepository PictureRepository { get; }
        public ProductRepository ProductRepository { get; }

        public ProductController(ProductRepository produitRepository, PictureRepository pictureRepository)
        {
            this.ProductRepository = produitRepository;
            this.PictureRepository = pictureRepository;
        }

        public IActionResult Index()
        {
            var produits = this.ProductRepository.FindAll();
            return View(produits);
        }

        public IActionResult DeletePhoto(int id, int productId)
        {
            var Product = ProductRepository.FindById(productId);
            var Picture = Product.Pictures.Single(b => b.Id == id);
            Product.Pictures.Remove(Picture);

            PictureRepository.Delete(id);
            return RedirectToAction("Details", new { id = productId });

        }

        public IActionResult Details(int id)
        {
            var produit = this.ProductRepository.FindById(id);
            return View(produit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductPictureViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                var Files = viewModel.PicturesToBeUploaded;
                var produit = new Product
                {
                    Reference = viewModel.Reference,
                    Description = viewModel.Description,
                    Pictures = PictureRepository.Create(Files)
                };
                ProductRepository.Create(produit);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }


        public IActionResult Edit(int id)
        {
            var produit = this.ProductRepository.FindById(id);
            ProductPictureViewModel viewModel = new()
            {
                ProductId = produit.Id,
                Reference = produit.Reference,
                Description = produit.Description,
                Pictures = produit.Pictures
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductPictureViewModel viewModel)
        {
            var Files = viewModel.PicturesToBeUploaded;
            IList<Picture> pictures = new List<Picture>();
            if (viewModel.Pictures != null)
            {
                pictures = viewModel.Pictures;
            }
            Product editedProduct = new Product
            {
                Id = id,
                Reference = viewModel.Reference,
                Description = viewModel.Description,
                Pictures = pictures.Concat(PictureRepository.Create(Files)).ToList()
            };
            this.ProductRepository.Update(id, editedProduct);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            var produit = this.ProductRepository.FindById(id);
            ProductPictureViewModel viewModel = new()
            {
                ProductId = produit.Id,
                Reference = produit.Reference,
                Description = produit.Description
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id, ProductPictureViewModel produit)
        {
            try
            {
                this.ProductRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
