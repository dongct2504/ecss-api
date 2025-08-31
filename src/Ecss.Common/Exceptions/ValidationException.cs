using Ecss.Common.Errors;

namespace Ecss.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(List<ValidationError> errors) : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }

    public List<ValidationError> Errors { get; }
}
