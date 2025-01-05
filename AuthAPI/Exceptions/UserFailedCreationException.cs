using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class UserFailedCreationException : BaseApplicationException
{
    public UserFailedCreationException(ProblemDetails problemDetails): base(problemDetails)
    {
        
    }

    public UserFailedCreationException(string message) : base(new ProblemDetails
    {
        Status = StatusCodes.Status400BadRequest,
        Title = "User Creation Failed",
        Detail = message
    })
    {

    }
}
