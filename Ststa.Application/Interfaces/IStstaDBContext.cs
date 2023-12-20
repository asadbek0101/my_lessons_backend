using Microsoft.EntityFrameworkCore;
using Ststa.Domain.Entites;

namespace Ststa.Application.Interfaces;

public interface IStstaDBContext
{
    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<Test> Tests { get; set; }

    public DbSet<Theme> Themes { get; set; }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Answer> Answers { get; set; }

    public DbSet<UserTest> UserTests { get; set; }

    public DbSet<UserQuestions> UserQuestions { get; set; }

    public DbSet<Result> Results { get; set; }

    public DbSet<Page> Pages { get; set; }

    public DbSet<Images> Images { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
