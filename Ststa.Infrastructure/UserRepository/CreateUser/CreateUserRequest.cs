﻿using MediatR;

namespace Ststa.Infrastructure.UserRepository.CreateUser;

public sealed record CreateUserRequest : IRequest<CreateUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
}
