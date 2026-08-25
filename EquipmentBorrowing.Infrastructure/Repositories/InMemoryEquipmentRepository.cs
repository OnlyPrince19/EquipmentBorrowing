using EquipmentBorrowing.Application.Interfaces;
using EquipmentBorrowing.Domain;

namespace EquipmentBorrowing.Infrastructure.Repositories;

public class InMemoryEquipmentRepository : IEquipmentRepository
{
    private readonly List<Equipment> _equipment = new()
    {
        new Equipment { Id = 1, Name = "Projector", IsAvailable = true },
        new Equipment { Id = 2, Name = "Laptop", IsAvailable = false }
    };

    public Task<Equipment?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var item = _equipment.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(item);
    }
}