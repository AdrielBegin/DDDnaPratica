using BuberDinner.Contracts.AuthenticationResponse;
using BuberDinner.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationServices _authenticationServices;

    public AuthenticationController(IAuthenticationServices authenticationServices)
    {        
        _authenticationServices = authenticationServices;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authResult = _authenticationServices.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);
        
        var reponse = new  AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );    

        return Ok(reponse);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequestregister)
    {

        var authResult = _authenticationServices.Login(
            loginRequestregister.Email,
            loginRequestregister.Password);
        
        var reponse = new  AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );   

        return Ok(reponse);
    }


}