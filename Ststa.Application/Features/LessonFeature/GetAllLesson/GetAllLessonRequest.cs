
using MediatR;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.LessonFeature.GetAllLesson;

public record class GetAllLessonRequest : IRequest<PaginatorApiResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchValue { get; set; }
    public string? Status { get; set; }
}
