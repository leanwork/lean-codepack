using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack.Storage.Azure
{
    public class AzureStorageSettings
    {
        public static string BLOB_URL
        {
            get { return ConfigurationManager.AppSettings["AZURE_STORAGE.BLOB_URL"] ?? String.Empty; }
        }

        public static string CONNECTION_STRING
        {
            get { return ConfigurationManager.AppSettings["AZURE_STORAGE.CONNECTION_STRING"] ?? String.Empty; }
        }
    }
}
