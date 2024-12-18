namespace app_store.Domain.Helper
{
    public class Result
    {
        #region Ctors

        public Result(bool success) => IsSuccess = success;
        public Result(
            bool success,
            string message)
        {
            IsSuccess = success;
            Message = message;
        }
        #endregion

        #region Props

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; } = string.Empty;
        #endregion

        #region Methods

        public static Result Failure() => new Result(false);
        public static Result Failure(string message) => new Result(false, message);

        public static Result Success() => new Result(true);
        public static Result Success(string message) => new Result(true, message);
        #endregion
    }


    public class Result<T> : Result
    {
        #region Ctors

        public Result(
            bool issuccess,
            T data)
            : base(issuccess)
        {
            Data = data;
        }
        public Result(
            bool issuccess,
            string message,
            T data)
            : base(issuccess, message)
        {
            Data = data;
        }
        #endregion

        #region Props

        /// <summary>
        /// return operation data
        /// </summary>
        public T? Data { get; private set; }
        #endregion

        #region Methods

        public static Result<T> Failure(T? data) => new Result<T>(false, data);
        public static Result<T> Failure(string message, T? data) => new Result<T>(false, message, data);

        public static Result<T> Success(T? data) => new Result<T>(true, data);
        public static Result<T> Success(string message, T? data) => new Result<T>(true, message, data);
        #endregion
    }
}
