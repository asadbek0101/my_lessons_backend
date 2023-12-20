using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.PageFeature.GetAllPage;

public class GetAllPageHandler : IRequestHandler<GetAllPageRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IPaginator _paginator;

    public GetAllPageHandler(IMapper mapper, IStstaDBContext ststaDBContext, IPaginator paginator)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllPageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var type = ResponseType.Success;
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
            var lessons = await _dbContext.Pages.OrderBy(b => b.Id).Skip(skipRows).Take(request.PageSize).ToListAsync(cancellationToken);
            var data = new List<GetAllPageResponse>();

            if (lessons == null)
            {
                type = ResponseType.NotFound;
            }
            else
            {
                data = _mapper.Map<List<GetAllPageResponse>>(lessons);
            }

            return ResponseHandler.GetAppResponse(type, data);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
