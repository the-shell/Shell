using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.UI.ViewModels.Organisation
{
    public class CreateViewModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        //public static implicit operator CreateViewModel(Product product)
        //{
        //    var vm = new CreateViewModel
        //    {
        //        Title = product.Title,
        //        Description = product.Description,
        //        Price = product.Price
        //    };
        //    return vm;
        //}

        //public static implicit operator Product(CreateViewModel vm)
        //{
        //    var product = new Product();
        //    product.Title = vm.Title;
        //    product.Description = vm.Description;
        //    product.Price = vm.Price;
            
        //    return product;
        //}
    }
}