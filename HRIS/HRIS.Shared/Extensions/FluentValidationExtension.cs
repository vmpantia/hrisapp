using FluentValidation.Results;

namespace HRIS.Shared.Extensions;

public static class FluentValidationExtension
{
    public static IDictionary<string, string[]> ToDictionary(this IEnumerable<ValidationFailure> errors) =>
        errors.GroupBy(x => x.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray());
}