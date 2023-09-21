﻿using System.ComponentModel.DataAnnotations;
namespace ZenDriver.API.Security.Domain.Services.Communication;
public class AuthenticateRequest
{
    [Required] public string Username { get; set; } 
    [Required] public string Password { get; set; }
}