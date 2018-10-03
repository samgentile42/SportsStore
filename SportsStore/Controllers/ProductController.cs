﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int productPage = 1) =>
            View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage = 1) * PageSize)
                .Take(PageSize));
       

        public IActionResult Index()
        {
            return View();
        }
    }
}