using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shell.Models;
using Shell.ViewModels;
using Shell.Repository;
using Nelibur.ObjectMapper;

namespace Shell.Services
{
    public class ProductService : IProductService
    {
        private IImageService _imageService;
        private IProductRepository _productRepository;

        public ProductService(IImageService imageService, IProductRepository productRepository)
        {
            _imageService = imageService;
            _productRepository = productRepository;
        }

        public void Create(CreateProductViewModel productViewModel)
        {
            var dto = TinyMapper.Map<Product>(productViewModel);
            var productId = _productRepository.Insert(dto);
            var displayImage = _imageService.UploadImages(productViewModel.Images, productViewModel.BusinessId, productId);
            var product = _productRepository.GetById(productId);
            product.DisplayImage = displayImage;
            _productRepository.Update(product);
        }
    }
}