using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Users
{
  public class UserCommandHandler : IRequestHandler<CreateUserCommand>
                                    //IRequestHandler<LoginCommand, string>
  {
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserCommandHandler(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userRepository = userRepository;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      // Son parametre UserName'dir. Ekstra göndermemek için email'e eşitledik.
      User user = new User(request.Name, request.LastName, request.Email, request.Email);
      IdentityResult result = await _userManager.CreateAsync(user, request.Password);
      //_userRepository.CreateDapper(user);

      return Unit.Value;
    }

    //public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    //{
    //  SignInResult result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
    //  result.
    //}
  }
}
