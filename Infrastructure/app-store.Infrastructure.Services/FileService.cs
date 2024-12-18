using app_store.Domain.Entities;
using app_store.Domain.Enumerations;
using app_store.Domain.Helper;
using app_store.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace app_store.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly string _localFileBasePath;

        public FileService(IConfiguration configuration)
        {
            _localFileBasePath = configuration["FileStorage:LocalFileBasePath"];
        }

        public async Task<Result<Dictionary<FileStorageProvider, string>>> GetFileUrlsAsync(FileStorage fileStorage)
        {
            try
            {
                var fileUrls = new Dictionary<FileStorageProvider, string>();

                foreach (var provider in fileStorage.Providers)
                {
                    switch (provider)
                    {
                        case FileStorageProvider.Local:
                            fileUrls[FileStorageProvider.Local] = GetLocalFileUrl(fileStorage.FileName, fileStorage.ContentType);
                            break;

                        case FileStorageProvider.Amazon:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                return Result<Dictionary<FileStorageProvider, string>>.Success(fileUrls);
            }
            catch (Exception ex)
            {
                return Result<Dictionary<FileStorageProvider, string>>.Failure(ex.Message, null);
            }
          
        }

        private string GetLocalFileUrl(string fileName, string contentType)
        {
            string filePath = Path.Combine(_localFileBasePath, $"{fileName}{contentType}");
            return filePath;
        }
        public async Task<Result> UploadFileAsync(FileStorage fileStorage, Stream fileStream, FileStorageProvider provider)
        {
            try
            {
                switch (provider)
                {
                    case FileStorageProvider.Local:
                        UploadToLocal(fileStorage.FileName, fileStorage.ContentType, fileStream);
                        break;

                    case FileStorageProvider.Amazon:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
           
        }

        private void UploadToLocal(string fileName, string contentType, Stream fileStream)
        {
            var filePath = Path.Combine(_localFileBasePath, $"{fileName}{contentType}");

            using (var fileStreamLocal = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fileStream.CopyTo(fileStreamLocal);
            }
        }

        //private async Task<string> GeneratePresignedUrlAsync(string fileName, string contentType)
        //{
        //    var objectKey = $"{fileName}{contentType}";
        //    var request = new GetPreSignedUrlRequest
        //    {
        //        BucketName = _bucketName,
        //        Key = objectKey,
        //        Expires = DateTime.UtcNow.AddMinutes(10)
        //    };

        //    return _s3Client.GetPreSignedURL(request);
        //}


        //private async Task UploadToS3Async(string fileName, string contentType, Stream fileStream)
        //{
        //    var putRequest = new PutObjectRequest
        //    {
        //        BucketName = _bucketName,
        //        Key = $"{fileName}{contentType}",
        //        InputStream = fileStream,
        //        ContentType = contentType,
        //        CannedACL = S3CannedACL.PublicRead 
        //    };

        //    var response = await _s3Client.PutObjectAsync(putRequest);
        //}
    }
}
