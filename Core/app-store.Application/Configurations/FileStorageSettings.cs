namespace app_store.Application.Configurations
{
    public class FileStorageSettings 
    {
        public string LocalFileBasePath { get; set; }  = string.Empty;
        public string AwsAccessKey { get; set; } = string.Empty;
        public string AwsSecretKey { get; set; } = string.Empty;
        public string AwsRegion { get; set; } = string.Empty;
        public string AwsBucketName { get; set; } = string.Empty;
    }
}
