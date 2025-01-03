using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Extentions;
public static class ValidationResultExtentions
{
    public static IDictionary<string, string[]> ToValidationErrorMap(this IEnumerable<ValidationResult> validationResults)
    {
        return validationResults.SelectMany(r => r.Errors)
              .GroupBy(e => e.PropertyName)
              .ToDictionary(
                  g => g.Key,
                  g => g.Select(e => e.ErrorMessage).ToArray());
    }
}
