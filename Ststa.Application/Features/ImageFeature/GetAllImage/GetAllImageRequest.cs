using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.GetAllImage;

public sealed record GetAllImageRequest : IRequest<ApiResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
