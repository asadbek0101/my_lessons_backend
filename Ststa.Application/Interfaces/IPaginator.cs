
namespace Ststa.Application.Interfaces;

public interface IPaginator
{
    public int Offset(int pageNumber, int pageSize);

    public int GetTotalPageCount(int pageSize, int totalRowCount);
}
