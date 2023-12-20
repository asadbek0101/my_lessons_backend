using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Infrastructure.UserRepository.GetAllUser;

public sealed record GetAllUserRequest : IRequest<PaginatorApiResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchValue { get; set; }
    public string? Status { get; set; }
    public string UserId { get; set; }
}
