using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ThemeFeature.UpdateTheme;

public class UpdateThemeHandler : IRequestHandler<UpdateThemeRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateThemeHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateThemeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            ResponseType type = ResponseType.Success;
            var response = "";

            var theme = await _dbContext.Themes.Where(testc => testc.Id == request.Id).FirstOrDefaultAsync();
            if(theme == null)
            {
                type = ResponseType.NotFound;
            }
            else
            {
                _dbContext.Themes.Update(theme);
                theme.ThemeTitle = request.ThemeTitle;
                theme.LessonId = request.LessonId;
                theme.Status = request.Status;
                await _unitOfWork.Save(cancellationToken);
                response = "Theme Has Updated!";
            }

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
