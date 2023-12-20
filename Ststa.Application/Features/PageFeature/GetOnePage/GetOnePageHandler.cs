using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.PageFeature.GetOnePage;

public class GetOnePageHandler : IRequestHandler<GetOnePageRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;

    public GetOnePageHandler(IMapper mapper, IStstaDBContext ststaDBContext)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
    }
    public async Task<ApiResponse> Handle(GetOnePageRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = new ResponseType();
        var data = new GetOnePageResponse();
        try
        {
            var page = await _dbContext.Pages.FirstOrDefaultAsync(p => p.ThemeId == request.ThemeId && p.PageType == request.ThemeType);
            
            if (page == null)
            {
                type = ResponseType.NotFound;
                data =  null;
            }
            else
            {
                data = _mapper.Map<GetOnePageResponse>(page);
            }

            return ResponseHandler.GetAppResponse(type, data);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
        
    }
}
