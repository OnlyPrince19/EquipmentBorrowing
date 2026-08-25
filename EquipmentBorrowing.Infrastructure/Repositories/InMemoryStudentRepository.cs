using EquipmentBorrowing.Application.Interfaces;
using EquipmentBorrowing.Domain;

namespace EquipmentBorrowing.Infrastructure.Repositories;

public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Juan Dela Cruz", IsEligibleToBorrow = true, MaxBorrowLimit = 3 },
        new Student { Id = 2, Name = "Maria Santos", IsEligibleToBorrow = false, MaxBorrowLimit = 2 }
    };

    public Task<Student?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(student);
    }
}