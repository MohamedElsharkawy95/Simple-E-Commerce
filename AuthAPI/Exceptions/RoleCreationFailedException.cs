using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class RoleCreationFailedException : BaseApplicationException
{
    public RoleCreationFailedException(string detail) : base(new ProblemDetails
    {
        Status = StatusCodes.Status400BadRequest,
        Title = "Role Creation Failed",
        Detail = detail
    })
    {

    }
}
