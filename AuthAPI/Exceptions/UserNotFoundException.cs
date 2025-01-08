using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class UserNotFoundException : BaseApplicationException
{
    public UserNotFoundException(string email) : base(new ProblemDetails
    {
        Status = StatusCodes.Status400BadRequest,
        Title = "User Not Found",
        Detail = $"User with email {email} is not found"
    })
    {

    }
}
