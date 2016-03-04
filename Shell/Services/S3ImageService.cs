using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shell.Services
{
    public class S3ImageService : IImageService
    {
        string imagesBucket = "shell-product-images";

        IAmazonS3 _client;

        public void UploadImages(List<HttpPostedFileBase> files, int orgId, int productId)
        {
           using (_client = new AmazonS3Client())
            {
                try
                {
                    files.ForEach(
                        file => _client.PutObject(new PutObjectRequest
                        {
                            Key = orgId + "/" + productId + "/" + Guid.NewGuid(),
                            BucketName = imagesBucket,
                            InputStream = file.InputStream
                        })
                    );
                }
                catch
                {
                    //Investigate how to properly propogate exceptions
                    throw;
                }
            }
        }
    }
}