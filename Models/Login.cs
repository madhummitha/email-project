using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace smsproject.Models;

public class LoginModel

{
    public string? Email {get; set;}
    public string? Password {get; set;}
}

public class RegisterModel
{
    public string? UserName {get; set;}
    public string? Password{get;set;}
    public string? Email{get; set;}
    public string? Role{get; set;}
}

public class MsgModel

{
    public string? toEmail {get; set;}
    public string? message {get; set;}
    public string? sentTime {get; set;}
    public string? fromEmail {get; set;}
}
