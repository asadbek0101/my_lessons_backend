
using AutoMapper;
using MediatR;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;
using Ststa.WebApi.Exceptions;

namespace Ststa.Application.Features.ImageFeature.CreateImage;

public class CreateImageHandler : IRequestHandler<CreateImageRequest, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreateImageHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateImageRequest request, CancellationToken cancellationToken)
    {
        
        try
        {
            var image = _mapper.Map<Images>(request);
            ResponseType type = ResponseType.Success;
            if (image == null)
            {
                type = ResponseType.Failure;
            }
            else
            {
                _dbContext.Images.Add(image);
                await _unitOfWork.Save(cancellationToken);
            }

            return ResponseHandler.GetAppResponse(type, image.Id);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }

    }
}
