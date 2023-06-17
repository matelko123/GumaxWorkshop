using FluentValidation;

namespace GumaxWorkshop.Application.Common.PaginatedList;

public class PaginatedListValidator : AbstractValidator<PaginatedListRequest>
{
    // TODO: Not working...
    // Probably solution: https://docs.fluentvalidation.net/en/latest/inheritance.html
    public PaginatedListValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("Page number at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 25).WithMessage("Page size can only be between 1 and 25 per page");
    }
}