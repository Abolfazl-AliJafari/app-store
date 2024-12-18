using app_store.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_store.Domain.Entities
{
    public class FileStorage
    {
        #region Ctors
        public FileStorage() { }
        public FileStorage(
            string fileName,
            string contentType,
            long fileSize,
            FileStorageProvider[] providers)
        {
            FileName = fileName;
            ContentType = contentType;
            FileSize = fileSize;
            Providers = providers;
        }
        #endregion

        #region Props
        public Guid Id { get; private set; }
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public long FileSize { get; private set; }
        public FileStorageProvider[] Providers { get; private set; }
        #endregion

        #region Methods
        public void Update(
            string fileName,
            string contentType,
            long fileSize,
            FileStorageProvider[] providers)
        {
            FileName = fileName;
            ContentType = contentType;
            FileSize = fileSize;
            Providers = providers;
        }
        #endregion
    }
}
