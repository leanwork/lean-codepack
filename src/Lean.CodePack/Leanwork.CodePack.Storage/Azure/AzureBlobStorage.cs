using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack.Storage.Azure
{
    public class AzureBlobStorage
    {
        CloudStorageAccount _account;
        CloudBlobClient _blobClient;

        public AzureBlobStorage()
        {
            _account = CloudStorageAccount.Parse(AzureStorageSettings.CONNECTION_STRING);
            _blobClient = _account.CreateCloudBlobClient();
        }

        public string Upload(string containerName, string fileName, Stream stream)
        {
            if (null == fileName)
            {
                throw new ArgumentNullException("fileName");
            }
            if (null == stream)
            {
                throw new ArgumentNullException("stream");
            }

            CloudBlobContainer container = GetBlobContainer(containerName);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            stream.Seek(0, SeekOrigin.Begin);
            blockBlob.UploadFromStream(stream);

            return String.Format(AzureStorageSettings.BLOB_URL, containerName, fileName);
        }

        public bool Delete(string containerName, string fileName)
        {
            if (null == fileName)
            {
                throw new ArgumentNullException("fileName");
            }

            try
            {
                CloudBlobContainer container = GetBlobContainer(containerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                if (blockBlob != null)
                {
                    blockBlob.Delete();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        CloudBlobContainer GetBlobContainer(string containerName)
        {
            if (null == _blobClient)
            {
                throw new ArgumentNullException("blobClient");
            }

            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            return container;
        }
    }
}
