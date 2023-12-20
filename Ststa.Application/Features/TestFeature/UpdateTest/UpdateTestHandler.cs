using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ststa.Application.Interfaces;
using Ststa.Domain.Entites;

namespace Ststa.Application.Features.TestFeature.UpdateTest;

public class UpdateTestHandler : IRequestHandler<UpdateTestRequest, UpdateTestResponse>
{
    private readonly IMapper _mapper;
    private readonly IStstaDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTestHandler(IMapper mapper, IStstaDBContext ststaDBContext, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dbContext = ststaDBContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateTestResponse> Handle(UpdateTestRequest request, CancellationToken cancellationToken)
    {
        var Questions = request.Questions;

        
        // Update Question

        var test = await _dbContext.Tests.Where(t => t.Id == request.Id).FirstOrDefaultAsync();

        if (test != null)
        {
            test.TestTitle = request.TestTitle;
            _dbContext.Tests.Update(test);
            await _unitOfWork.Save(cancellationToken);
        }
        else return new UpdateTestResponse { Message = "Test Not Found" };

        foreach (var question in Questions)
        {
            var questionFromDb = await _dbContext.Questions.Where(q => q.Id == question.Id).FirstOrDefaultAsync();
            
            if (questionFromDb != null)
            {
                questionFromDb.QuestionTitle = question.Title;
                _dbContext.Questions.Update(questionFromDb);
                await _unitOfWork.Save(cancellationToken);

                // Update Answers

                foreach (var answer in question.Answers)
                {
                    var updateAnswer = await _dbContext.Answers.Where(a => a.Id == answer.Id).FirstOrDefaultAsync();

                    if (updateAnswer != null)
                    {
                        updateAnswer.AnswerTitle = answer.Title;
                        updateAnswer.IsRight = answer.IsRight;

                        _dbContext.Answers.Update(updateAnswer);
                        await _unitOfWork.Save(cancellationToken);
                    }
                }

                // Remove Answers

                var AnswersFromDb = await _dbContext.Answers.Where(a => a.QuestionId == question.Id).ToListAsync();

                foreach (var AnswerFromDb in AnswersFromDb)
                {
                    var hasAnswer = question.Answers.Where(a => a.Id == AnswerFromDb.Id).FirstOrDefault();

                    if (hasAnswer == null)
                    {
                        _dbContext.Answers.Remove(AnswerFromDb);
                        await _unitOfWork.Save(cancellationToken);
                    }
                }

                // Add Answers

                var newAnswers = question.Answers.Where(na => na.Id == null).ToList();

                if (newAnswers != null)
                {
                    foreach (var answer in newAnswers)
                    {
                        Answer answerToDb = new Answer
                        {
                            AnswerTitle = answer.Title,
                            QuestionId = question.Id ?? questionFromDb.Id,
                            IsRight = answer.IsRight,
                        };

                        _dbContext.Answers.Add(answerToDb);
                        await _unitOfWork.Save(cancellationToken);
                    }
                }

            }
        }

        // Remove Questions From Db 

        var QuestionFromDb = await _dbContext.Questions.Where(q => q.TestId == request.Id).ToListAsync();

        foreach (var question in QuestionFromDb)
        {
            var hasQuestion = Questions.Where(q => q.Id == question.Id).FirstOrDefault();

            if (hasQuestion == null)
            {
                _dbContext.Questions.Remove(question);
                await _unitOfWork.Save(cancellationToken);
            }
        }

        // Add Questions
        
        var newQuestins = request.Questions.Where(nq => nq.Id == null).ToList();

        if (newQuestins != null)
        {
            foreach (var question in newQuestins)
            {
                Question questionToDb = new Question
                {
                    QuestionTitle = question.Title,
                    TestId = request.Id,
                };

                _dbContext.Questions.Add(questionToDb);
                await _unitOfWork.Save(cancellationToken);

                foreach (var answer in question.Answers)
                {
                    Answer answerToDb = new Answer
                    {
                        AnswerTitle = answer.Title,
                        QuestionId = questionToDb.Id,
                        IsRight = answer.IsRight,
                    };

                    _dbContext.Answers.Add(answerToDb);
                    await _unitOfWork.Save(cancellationToken);
                }
            }
        }

        return new UpdateTestResponse { Message = "Test Has Updated" };
    }
}
