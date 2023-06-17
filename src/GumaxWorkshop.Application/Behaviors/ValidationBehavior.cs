using FluentValidation;
using GumaxWorkshop.Application.Common;
using MediatR;

namespace GumaxWorkshop.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationTasks = _validators.Select(v => v.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .Select(failure => new ValidationResponse
            {
                PropertyName = failure.PropertyName,
                Message = failure.ErrorMessage
            })
            .Distinct()
            .ToList();

        if (failures.Any())
        {        
            throw new Common.Exceptions.ValidationException(failures);
        }

        return await next();
    }
}