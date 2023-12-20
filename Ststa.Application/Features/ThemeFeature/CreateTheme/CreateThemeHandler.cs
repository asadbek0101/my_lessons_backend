using AutoMapper;
using MediatR;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.ThemeFeature.CreateTheme;

internal class CreateThemeHandler : IRequestHandler<CreateThemeRequest, CreateThemeResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreateThemeHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateThemeResponse> Handle(CreateThemeRequest request, CancellationToken cancellationToken)
    {
        var theme = _mapper.Map<Theme>(request);
        _dbContext.Themes.Add(theme);
          await _unitOfWork.Save(cancellationToken);
         
        return _mapper.Map<CreateThemeResponse>(theme);
    }
}
