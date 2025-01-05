using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class BaseApplicationException : ApplicationException
{
    public BaseApplicationException(ProblemDetails problemDetails) : base(problemDetails.Title)
    {
        Problem = problemDetails;
    }

    public BaseApplicationException(string message) : base(message)
    {
        Problem = new ProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = message
        };
    }

    public ProblemDetails Problem { get; }
}
