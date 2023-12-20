using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.GetImageByLesson;

public class GetImagesHandler : IRequestHandler<GetImagesRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;

    public GetImagesHandler(IMapper mapper, IStstaDBContext ststaDBContext)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
    }
    public async Task<ApiResponse> Handle(GetImagesRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        var data = new List<GetImagesResponse>();
        try
        {
            var images = await _dbContext.Images.Where(i => i.ThemeId == request.LessonId && i.Type == request.Type).OrderBy(i=>i.Id).ToListAsync();
            if (images == null )
            {
                type = ResponseType.NotFound;
            } else
            {
                data = _mapper.Map<List<GetImagesResponse>>(images);
            }

            return ResponseHandler.GetAppResponse(type, data);
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
