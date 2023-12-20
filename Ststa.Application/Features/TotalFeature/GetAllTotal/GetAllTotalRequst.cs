using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.TotalFeature.GetAllTotal;

public sealed record GetAllTotalRequst : IRequest<ApiResponse>
{
    public int UserId { get; set; }
}
