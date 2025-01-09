using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class BaseApplicationException : ApplicationException
{
    public BaseApplicationException(ProblemDetails problemDetails) : base(problemDetails.Title)
    {
        Problem = problemDetails;
    }

    public ProblemDetails Problem { get; }
}
