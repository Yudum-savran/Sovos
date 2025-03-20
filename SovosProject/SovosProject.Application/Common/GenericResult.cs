using Microsoft.AspNetCore.Http.HttpResults;

namespace SovosProject.Application.Common
{
    public class GenericResult<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public Error Error { get; }

        private GenericResult(bool isSuccess, T value, Error error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static GenericResult<T> Success(T value) => new GenericResult<T>(true, value, null);
        public static GenericResult<T> Failure(Error error) => new GenericResult<T>(false, default(T), error);
    }
}
