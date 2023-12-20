using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.TestFeature.CreateTest;

public class CreateTestHandler : IRequestHandler<CreateTestRequest, CreateTestResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTestHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateTestResponse> Handle(CreateTestRequest request, CancellationToken cancellationToken)
    {
        var Questions = request.Questions;
        var LessonId = request.LessonId;

        var Lesson = await _dbContext.Lessons.Where(l => l.Id == LessonId).FirstOrDefaultAsync();
        var isHasTest = await _dbContext.Tests.Where(t => t.ThemeId == LessonId).FirstOrDefaultAsync();

        Test testToDb = new Test
        {
            ThemeId = LessonId,
            TestTitle = Lesson.LessonTitle,
        };
        
        _dbContext.Tests.Add(testToDb);
        await _unitOfWork.Save(cancellationToken);

        foreach (var question in Questions)
        {
            Question questionToDb = new Question
            {
                QuestionTitle = question.QuestionTitle,
                TestId = testToDb.Id,
            };

            _dbContext.Questions.Add(questionToDb);
            await _unitOfWork.Save(cancellationToken);
            
            foreach (var answer in question.Answers)
            {
                Answer answerToDb = new Answer
                {
                   AnswerTitle = answer.AnswerTitle,
                   QuestionId = questionToDb.Id,
                   IsRight = answer.IsRight,
                };

                _dbContext.Answers.Add(answerToDb);
                await _unitOfWork.Save(cancellationToken);
            }
        }
        return new CreateTestResponse { ResponeMessage = "Test Created!" };
    }
}
