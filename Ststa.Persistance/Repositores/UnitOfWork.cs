
using Ststa.Application.Interfaces;

namespace Ststa.Persistance.Repositores;

public class UnitOfWork : IUnitOfWork
{
    private readonly IStstaDBContext _context;

    public UnitOfWork(IStstaDBContext context)
    {
        _context = context;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
