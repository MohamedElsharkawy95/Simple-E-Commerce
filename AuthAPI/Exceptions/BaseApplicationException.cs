using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class BaseApplicationException : ApplicationException
{
    public ProblemDetails Problem { get; }

    public BaseApplicationException(ProblemDetails problemDetails)
    {
        Problem = problemDetails;
    }
}
