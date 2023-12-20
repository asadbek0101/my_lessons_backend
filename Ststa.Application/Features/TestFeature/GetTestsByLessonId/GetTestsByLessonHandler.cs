
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;

namespace Ststa.Application.Features.TestFeature.GetTestsByLessonId;

public class GetTestsByLessonHandler : IRequestHandler<GetTestsRequest, GetTestsResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaginator _paginator;

    public GetTestsByLessonHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork, IPaginator paginator)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
        _paginator = paginator;
    }
    public async Task<GetTestsResponse> Handle(GetTestsRequest request, CancellationToken cancellationToken)
    {
        var lesson = await _dbContext.Lessons.Where(l => l.Id == request.ThemeId).FirstOrDefaultAsync(); 
        var test = await _dbContext.Tests.Where(t => t.ThemeId == request.ThemeId).FirstOrDefaultAsync();
        var questions = await _dbContext.Questions.Where(q => q.TestId == test.Id).OrderBy(q=>q.Id).ToListAsync();
        var questionsToFront = new List<GetTestsQuestion>();

        questions.ForEach( q =>
        {
            var answersToFront = new List<GetTestsAnswer>();
            var answers =  _dbContext.Answers.Where(a => a.QuestionId == q.Id).OrderBy(a=>a.Id).ToList();
            answers.ForEach(a =>
            {
                answersToFront.Add(
                   new GetTestsAnswer
                   {
                       Id = a.Id,
                       Title = a.AnswerTitle,
                       IsRight = a.IsRight,
                       QuestionId = a.QuestionId,
                   });
            });

            questionsToFront.Add(new GetTestsQuestion
            {
                Id = q.Id,
                Title = q.QuestionTitle,
                TestId = q.TestId,
                Answers = answersToFront,
            });
        });

        var response = new GetTestsResponse
        {
            Id = test.Id,
            LessonId = test.ThemeId,
            TestTitle = test.TestTitle ?? lesson.LessonTitle,
            Questions = questionsToFront,
        };
        return response;
    }
}
