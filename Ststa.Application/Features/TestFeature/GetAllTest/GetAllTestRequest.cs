
using MediatR;

namespace Ststa.Application.Features.TestFeature.GetAllTest;

public sealed record GetAllTestRequest : IRequest<List<GetAllTestResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
