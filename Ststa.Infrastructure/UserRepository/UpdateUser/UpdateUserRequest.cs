﻿
using MediatR;

namespace Ststa.Infrastructure.UserRepository.UpdateUser;

public sealed record UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
}
