using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace smsproject.Models;

public class EmpModel

{
    public string? Name {get; set;}
    public string? Password {get; set;}
}

public class EmpRegister
{
    public string? UserName {get; set;}
    public string? Password{get;set;}
    public string? Email{get; set;}
    public string? Role{get; set;}
}
