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
        /// <summary>
        /// Uploads all the images given to an Amazon S3 bucket.
        /// </summary>
        /// <param name="files">The images to be uploaded</param>
        /// <param name="orgId">The business's Id that the products images belong to</param>
        /// <param name="productId">The product Id that the images belong to</param>
        /// <returns>The main image file name</returns>
        string UploadImages(List<Tuple<HttpPostedFileBase, bool>> files, int orgId, int productId);

        /// <summary>
        /// Returns all the URLs of the products images. 
        /// </summary>
        /// <param name="orgId">The business Id the product belongs to</param>
        /// <param name="productId">The product Id that the image URLs belong to</param>
        /// <returns>The image URLs for the product</returns>
        List<string> GetImageURLs(int orgId, int productId);

        /// <summary>
        /// Deletes all the images for a product
        /// </summary>
        /// <param name="orgId">The business Id the product belongs to</param>
        /// <param name="productId">The product Id that the image URLs belong to</param>
        void DeleteImages(int orgId, int productId);
    }
}
