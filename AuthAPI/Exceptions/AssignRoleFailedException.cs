using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Exceptions;

public class AssignRoleFailedException : BaseApplicationException
{
    public AssignRoleFailedException(string roleName, string email) : base(new ProblemDetails
    {
        Status = StatusCodes.Status400BadRequest,
        Title = "Assigning Role Failed",
        Detail = $"Failed to assign role {roleName} to user with email {email}"
    })
    {

    }
}
