using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.CloudSearchDomain;
using Amazon.S3;
using Amazon.S3.Model;

namespace Shell.DAL
{
    public class S3Client
    {
        private readonly string ImageBucket = "shell-image-bucket";

        private static AmazonS3Client client;

        public S3Client()
        {
            client = new Amazon.S3.AmazonS3Client(Amazon.RegionEndpoint.APSoutheast2);
        }

        public string PutImage(HttpPostedFileBase file)
        {
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = ImageBucket,
                Key = file.FileName,
                ContentType = "image/jpeg",
                InputStream = file.InputStream
            };
            PutObjectResponse response = client.PutObject(request);

            return GetURL(file.FileName);
        }

        private string GetURL(string fileName)
        {
            string URL = string.Format("https://s3-ap-southeast-2.amazonaws.com/{0}/{1}", ImageBucket, fileName);

            return URL;
        }

       
    }

    class ListObjectsVersioningEnabledBucket
    {
        static string bucketName = "shell-image-bucket";

        public static void Main(string[] args)
        {
            using (var client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast2))
            {
                Console.WriteLine("Listing objects stored in a bucket");

                GetObjectListWithAllVersions(client);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void GetObjectListWithAllVersions(IAmazonS3 client)
        {
            try
            {
                ListVersionsRequest request = new ListVersionsRequest()
                {
                    BucketName = bucketName,
                    
                    MaxKeys = 2
                };
                do
                {
                    ListVersionsResponse response = client.ListVersions(request);
                    // Process response.
                    foreach (S3ObjectVersion entry in response.Versions)
                    {
                        Console.WriteLine("key = {0} size = {1}",
                            entry.Key, entry.Size);
                    }

                    // If response is truncated, set the marker to get the next 
                    // set of keys.
                    if (response.IsTruncated)
                    {
                        request.KeyMarker = response.NextKeyMarker;
                        request.VersionIdMarker = response.NextVersionIdMarker;
                    }
                    else
                    {
                        request = null;
                    }
                } while (request != null);

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    Console.WriteLine("Check the provided AWS Credentials.");
                    Console.WriteLine(
                    "To sign up for service, go to http://aws.amazon.com/s3");
                }
                else
                {
                    Console.WriteLine(
                     "Error occurred. Message:'{0}' when listing objects",
                     amazonS3Exception.Message);
                }
            }
        }
    }
}