using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shell.Services
{
    public interface IImageService
    {
        void UploadImages(List<HttpPostedFileBase> files, int orgId, int productId);
    }
}
