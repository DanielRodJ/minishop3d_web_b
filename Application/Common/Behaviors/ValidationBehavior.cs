using Domain.Common;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, T>
    : IPipelineBehavior<TRequest, Result<T>>
    where TRequest : IRequest<Result<T>>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Result<T>> Handle(
            TRequest request,
            RequestHandlerDelegate<Result<T>> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure is not null)
                .Select(failure => Error.Validation(failure.PropertyName, failure.ErrorMessage))
                .ToArray();

            if (errors.Length > 0)
            {
                var validationError = new ValidationError(errors);

                return Result.Failure<T>(validationError);
            }

            return await next();
        }
    }
}