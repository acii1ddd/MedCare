using AutoMapper;
using MedCare.API.Contracts.Requests;
using MedCare.API.Contracts.Responses.Account;
using MedCare.BLL.Interfaces.Auth;
using MedCare.BLL.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AccountController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AccountController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignInResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignInAsync(SignInRequest request)
    {
        var authAccessTokenModel = await _authService.SignIn(_mapper.Map<SignInModel>(request));
        return Ok
        (
            _mapper.Map<SignInResponse>(authAccessTokenModel)
        );
    }

    [Authorize]
    [HttpGet("user-role")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserRoleResponse))]
    public IActionResult GetUserRoleAsync()
    {
        return Ok(_mapper.Map<GetUserRoleResponse>(AuthorizedUserRole));
    }
}