using Nelibur.ObjectMapper;
using Shell.Models;
using Shell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.App_Start
{
    public class MapConfig
    {
        public static void RegisterMappings()
        {
            TinyMapper.Bind<CreateProductViewModel, Product>(config =>
            {
                config.Ignore(source => source.Images);
            });
        }
    }
}