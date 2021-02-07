using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using NackademinWebShop.Models;
using NackademinWebShop.Repository.CategoryRepository;
using NackademinWebShop.Repository.ProductRepository;
using NackademinWebShop.ViewModels.Admin.Product;
using NackademinWebShop.ViewModels.Products;

namespace NackademinWebShop.Services.ProductService
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public ProductIndexViewModel Get(int id)
        {
            return _mapper.Map<ProductIndexViewModel>(_productRepository.Get(id));
        }

        public List<AdminProductViewModel> GetAll()
        {
            List<AdminProductViewModel> adminProductViewModels = new List<AdminProductViewModel>();
            foreach (Product product in _productRepository.GetAll())
            {
                var tmp = _mapper.Map<AdminProductViewModel>(product);
                adminProductViewModels.Add(tmp);
            }

            return adminProductViewModels;
        }

        public List<ProductIndexViewModel> GetSearchResult(string query, string sortOrder)
        {
            var products = _productRepository.GetAll();
            var model = _mapper.Map<List<ProductIndexViewModel>>(products.Where(i => query == null || i.Name.ToLower().Contains(query.ToLower()) || i.Description.ToLower().Contains(query.ToLower())).ToList());

            if (sortOrder == "asc")
                return model.OrderBy(p => p.Price).ToList();
            if (sortOrder == "desc")
                return model.OrderByDescending(p => p.Price).ToList();

            return model;
        }

        public AdminProductEditViewModel GetEdit(int id)
        {
            var model = _mapper.Map<AdminProductEditViewModel>(_productRepository.Get(id));
            model.Categories = GetCategoriesList();
            return model;
        }

        public List<SelectListItem> GetCategoriesList()
        {
            var categories = _categoryRepository.GetAll(true);
            var list = new List<SelectListItem>();
            list.AddRange(categories.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }));

            return list;
        }

        public void Update(AdminProductEditViewModel model)
        {
            var product = _mapper.Map<Product>(model);

            if (model.NewProductPicture != null)
                product.ProductPicture = ReplaceFile(model);

            if (model.Name != model.OldName) //name changed
                model.ProductPicture = RenameImgFolder(model);

            _productRepository.Update(product);
        }

        private string RenameImgFolder(AdminProductEditViewModel model)
        {
            string[] oldPath = model.ProductPicture.Split("\\");
            string newPath = $"{model.Name}\\{oldPath[1]}";
            string folderToRename = $"{_webHostEnvironment.WebRootPath}\\img\\{oldPath[0]}";
            string newFolderName = $"{_webHostEnvironment.WebRootPath}\\img\\{model.Name}";
            Directory.Move(folderToRename, newFolderName);
            return newPath;
        }

        private string ReplaceFile(AdminProductEditViewModel model)
        {
            string path = $"{_webHostEnvironment.WebRootPath}\\img\\{model.ProductPicture}";

            if (File.Exists(path))
                File.Delete(path);

            string test = UploadFile(model);

            return test;
        }

        public void Create(AdminProductCreateViewModel model)
        {
            string uniqueFileName = UploadFile(model);

            var product = _mapper.Map<Product>(model);
            product.ProductPicture = uniqueFileName;
            product.Category = _categoryRepository.GetById(model.CategoryId);
            _productRepository.Create(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        //TODO REFACTOR ME
        private string UploadFile(AdminProductCreateViewModel model)
        {
            string fileName = null;

            if (model.ProductPicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, $@"img\{model.Name}");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                fileName = model.ProductPicture.FileName;

                string filePath = Path.Combine(uploadsFolder, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.ProductPicture.CopyTo(fileStream);
            }
            return $@"{model.Name}\{fileName}";
        }

        private string UploadFile(AdminProductEditViewModel model)
        {
            string fileName = null;

            if (model.NewProductPicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, $@"img\{model.Name}");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                fileName = model.NewProductPicture.FileName;

                string filePath = Path.Combine(uploadsFolder, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.NewProductPicture.CopyTo(fileStream);
            }
            return $@"{model.Name}\{fileName}";
        }
    }
}