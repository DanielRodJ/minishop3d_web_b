namespace Domain.Common
{
    public sealed class Result<T> : Result
    {
        private readonly T _value;

        internal Result(T value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public T Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("No se puede acceder al valor de un resultado fallido.");
    }
}