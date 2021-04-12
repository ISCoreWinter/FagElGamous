using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class s3upload
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;
        private static readonly string key = "AKIAQOQ32YAWNVR4CRGE";
        private static readonly string key2 = "muP2Tn0hRbChInCoxNKY++niQHZSM0JmGOCuTzVr";

        public static async Task UploadFileAsync(Stream FileStream, string bucketname, string keyName)
        {
            s3Client = new AmazonS3Client(key, key2, bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(FileStream, bucketname, keyName);
        }

        public static async Task<GetObjectResponse> ReadObjectData(string bucketname, string keyName)
        {
            s3Client = new AmazonS3Client(key, key2, bucketRegion);
            var request = new GetObjectRequest
            {
                BucketName = bucketname,
                Key = keyName
            };
            
            var response = await s3Client.GetObjectAsync(request);

            return response;
        }
    }
}
