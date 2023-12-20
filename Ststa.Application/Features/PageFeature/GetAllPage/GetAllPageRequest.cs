
using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.PageFeature.GetAllPage;

public sealed record GetAllPageRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } 
}
