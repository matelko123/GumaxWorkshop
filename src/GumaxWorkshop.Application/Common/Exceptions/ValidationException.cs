namespace GumaxWorkshop.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationFailureResponse Failures { get; }

    public ValidationException(ValidationFailureResponse failures)
    {
        Failures = failures;
    }
    
    public ValidationException(IEnumerable<ValidationResponse> failures)
    {
        Failures = new ValidationFailureResponse
        {
            Errors = failures.ToList()
        };
    }
}