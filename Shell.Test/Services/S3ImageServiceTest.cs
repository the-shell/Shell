using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shell.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shell.Test.Services
{
    [TestClass]
    public class S3ImageServiceTest
    {
        IImageService imageService;

        [TestMethod]
        public void ImagesUploadedIntoS3WithCorrectBusinessAndProductName()
        {
            SetUp();

            int orgId = 1;
            int productId = 1;
            string imageLocations = "C:\\Users\\awsuser\\aws\\testimages";
            var mockImages = new List<HttpPostedFileBase>();


            foreach (var filePath in Directory.GetFiles(imageLocations))
            {
                MemoryStream ms = new MemoryStream();

                var img = Image.FromFile(filePath);
                img.Save(ms, ImageFormat.Png);
                var i = new Mock<HttpPostedFileBase>();
                i.Setup(file => file.InputStream).Returns(ms);
                mockImages.Add(i.Object);
            }
            imageService.UploadImages(mockImages, orgId, productId);
        
            var urls = imageService.GetImageURLs(orgId, productId);
            Assert.AreEqual(3, urls.Count());
        }

    private void SetUp()
    {
        imageService = new S3ImageService();
    }
}
}
