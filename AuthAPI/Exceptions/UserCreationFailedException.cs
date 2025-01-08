using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class UserCreationFailedException : BaseApplicationException
{
    public UserCreationFailedException(ProblemDetails problemDetails): base(problemDetails)
    {
        
    }

    public UserCreationFailedException(string message) : base(new ProblemDetails
    {
        Status = StatusCodes.Status400BadRequest,
        Title = "User Creation Failed",
        Detail = message
    })
    {

    }
}
