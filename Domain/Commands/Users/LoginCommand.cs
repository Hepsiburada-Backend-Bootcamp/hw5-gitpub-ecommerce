﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Users
{
  public class LoginCommand : IRequest<string>
  {
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginCommand(string email, string password)
    {
      Email = email;
      Password = password;
    }
  }
}
