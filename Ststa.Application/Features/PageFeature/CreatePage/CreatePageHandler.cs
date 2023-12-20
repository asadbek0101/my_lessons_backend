
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.PageFeature.CreatePage;

public class CreatePageHandler : IRequestHandler<CreatePageRequest, CreatePageResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePageHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreatePageResponse> Handle(CreatePageRequest request, CancellationToken cancellationToken)
    {
        var page = _mapper.Map<Page>(request);
        var isHasPage = await _dbContext.Pages.Where(p => p.ThemeId == request.ThemeId).FirstOrDefaultAsync();
        if (isHasPage == null)
        {
            _dbContext.Pages.Add(page);
            await _unitOfWork.Save(cancellationToken);
        }
        else
        {
            isHasPage.PageDetails = request.PageDetails;
            _dbContext.Pages.Update(isHasPage);
            await _unitOfWork.Save(cancellationToken);
        }
        
        return _mapper.Map<CreatePageResponse>(page);
    }
}
