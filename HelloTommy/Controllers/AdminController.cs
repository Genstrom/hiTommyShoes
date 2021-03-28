﻿using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace HelloTommy.Controllers
{

    [Route("admin")]
    public class AdminController : Controller
    {
        public BrandServices _brandServices;

        public ShoeServices _shoesService;

        public AdminController(BrandServices brandServices, ShoeServices shoesService)
        {
            _brandServices = brandServices;
            _shoesService = shoesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            return View(myModel);
        }

        [Route("add-shoe")]
        [HttpGet]
        public IActionResult AddShoeView()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            return View(myModel);
        }

        [Route("add-shoe")]
        [HttpPost]
        public ActionResult AddShoeView(string name, int price, int size, int quantity, int brandId, string picture, string description)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    var shoe = new ShoeViewModel()
                    {
                        Name = name,
                        Price = price,
                        BrandId = brandId,
                        PictureUrl = picture,
                        Description = description,
                        Size = size
                    };

                    if (!string.IsNullOrWhiteSpace(shoe.Description))
                    {
                        _shoesService.AddShoe(shoe);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return RedirectToAction("Index", myModel);
        }

        [Route("delete-shoe")]
        [HttpGet]
        public IActionResult DeleteShoeView()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }

        [Route("delete-shoe")]
        [HttpPost]
        public ActionResult DeleteShoeView(int id)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();


            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    _shoesService.DeleteShoeById(id);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return RedirectToAction("Index", myModel);
        }

        [Route("add-brand")]
        [HttpGet]
        public IActionResult AddBrandView()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }

        [Route("add-brand")]
        [HttpPost]
        public ActionResult AddBrandView(string name)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();


            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    var brand = new BrandVm()
                    {
                        Name = name,
                    };

                    if (!string.IsNullOrWhiteSpace(brand.Name))
                    {
                        _brandServices.AddBrand(brand);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return RedirectToAction("Index", myModel);
        }

        [Route("delete-brand")]
        [HttpGet]
        public IActionResult DeleteBrandView()
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();

            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;


            return View(myModel);
        }

        [Route("delete-brand")]
        [HttpPost]
        public ActionResult DeleteBrandView(int id)
        {
            var allShoesVm = new ShoeListViewModel
            {
                Shoes = _shoesService.GetAllShoes()
            };
            var allBrandsVM = _brandServices.GetAllBrands();


            dynamic myModel = new ExpandoObject();

            myModel.AllShoes = allShoesVm.Shoes;
            myModel.Brand = allBrandsVM;

            try
            {
                if (ModelState.IsValid)
                {
                    _brandServices.DeleteBrandById(id);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return RedirectToAction("Index", myModel);
        }
    }
}