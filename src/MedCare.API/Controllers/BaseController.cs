using System.Security.Claims;
using MedCare.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected Guid AuthorizedUserId
    {
        get
        {
            var userId = User.FindFirstValue("userId");
            return userId is null ? Guid.Empty : Guid.Parse(userId);
        }
    }

    protected string AuthorizedUserRole
    {
        get
        {
            var userRole = User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType);
            return userRole ?? string.Empty;
        }
    }
}