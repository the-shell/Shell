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

            var imageList = new List<Tuple<HttpPostedFileBase, bool>>();

            MemoryStream ms = new MemoryStream();
            var img = Image.FromFile("C:\\Users\\awsuser\\aws\\testimages\\11.PNG");
            img.Save(ms, ImageFormat.Png);
            var mockImage = new Mock<HttpPostedFileBase>();
            mockImage.Setup(o => o.InputStream).Returns(ms);
            var listObject = new Tuple<HttpPostedFileBase,bool>(mockImage.Object, true);
            imageList.Add(listObject);

            ms = new MemoryStream();
            img = Image.FromFile("C:\\Users\\awsuser\\aws\\testimages\\12.PNG");
            img.Save(ms, ImageFormat.Png);
            mockImage = new Mock<HttpPostedFileBase>();
            mockImage.Setup(o => o.InputStream).Returns(ms);
            listObject = new Tuple<HttpPostedFileBase, bool>(mockImage.Object, false);
            imageList.Add(listObject);

            var displayImage = imageService.UploadImages(imageList, orgId, productId);
            Assert.AreNotEqual("", displayImage);

            var urls = imageService.GetImageURLs(orgId, productId);
            Assert.AreEqual(2, urls.Count());

            imageService.DeleteImages(orgId, productId);
            urls = imageService.GetImageURLs(orgId, productId);
            Assert.AreEqual(0, urls.Count());
        }

        

    private void SetUp()
    {
        imageService = new S3ImageService();
    }
}
}
