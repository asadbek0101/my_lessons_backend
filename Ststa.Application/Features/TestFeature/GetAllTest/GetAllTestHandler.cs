using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;

namespace Ststa.Application.Features.TestFeature.GetAllTest;

public class GetAllTestHandler : IRequestHandler<GetAllTestRequest, List<GetAllTestResponse>>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaginator _paginator;

    public GetAllTestHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork, IPaginator paginator)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
        _paginator = paginator;
    }
    public async Task<List<GetAllTestResponse>> Handle(GetAllTestRequest request, CancellationToken cancellationToken)
    {
        var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
        var tests = await _dbContext.Tests.OrderBy(x => x.Id).Skip(skipRows).Take(request.PageSize).ToListAsync();
        return _mapper.Map<List<GetAllTestResponse>>(tests);
    }
}

