using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.GetAllImage;

public class GetAllImageHandler : IRequestHandler<GetAllImageRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IPaginator _paginator;

    public GetAllImageHandler(IMapper mapper, IStstaDBContext ststaDBContext, IPaginator paginator)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllImageRequest request, CancellationToken cancellationToken)
    {
        var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
        try
        {
            ResponseType type = ResponseType.Success;
            var images = await _dbContext.Images.OrderBy(x => x.Id).Skip(skipRows).Take(request.PageSize).ToListAsync();
            var data = new List<GetAllImageResponse>();
            if(!images.Any())
            {
                type = ResponseType.NotFound;
            }
            else
            {
                data = _mapper.Map<List<GetAllImageResponse>>(images);
            }

            return ResponseHandler.GetAppResponse(type, data);
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
