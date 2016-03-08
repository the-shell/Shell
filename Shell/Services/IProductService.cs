using Shell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Services
{
    public interface IProductService
    {
        void Create(Product product);
    }
}
