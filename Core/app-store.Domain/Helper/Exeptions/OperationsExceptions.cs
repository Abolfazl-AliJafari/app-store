namespace app_store.Domain.Helper.Exeptions
{
    public static class OperationsExceptions
    {
        public static string SuccessAdd(string entityName)
            => new($"{entityName} Successfully added. ");
        public static string SuccessRemove(string entityName,Guid id)
            => new($"{entityName} With id:{id} successfully removed. ");
        public static string SuccessUpdate(string entityName, Guid id)
            => new($"{entityName} With id:{id} successfully updated. ");
        public static string SuccessGetData(string entityName)
            => new($"{entityName} Successfully geted. ");

        public static string FailAdd(string entityName)
            => new($"{entityName} Is not successfully added. ");
        public static string FailRemove(string entityName,Guid id)
            => new($"{entityName} With id:{id} is not successfully removed. ");
        public static string FailUpdate(string entityName,Guid id)
            => new($"{entityName} With id:{id} is not successfully updated. ");
        public static string FailGetData(string entityName)
            => new($"{entityName} is not successfully geted. ");


        public static string NotFound(string entityName,Guid id)
            => new($"{entityName} With id:{id} was not found. ");
        public static string NoData(string entityName)
            => new($"{entityName} Don't have any data. ");

    }
}
