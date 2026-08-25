using EquipmentBorrowing.Application.Interfaces;
using EquipmentBorrowing.Domain;

namespace EquipmentBorrowing.Infrastructure.Repositories;

public class InMemoryBorrowingRepository : IBorrowingRepository
{
    private readonly List<Borrowing> _borrowings = new();

    public Task<int> GetActiveBorrowingCountAsync(int studentId, CancellationToken ct = default)
    {
        int count = _borrowings.Count(b => b.StudentId == studentId && b.Status == BorrowingStatus.Active);
        return Task.FromResult(count);
    }

    public Task AddAsync(Borrowing borrowing, CancellationToken ct = default)
    {
        _borrowings.Add(borrowing);
        return Task.CompletedTask;
    }
}