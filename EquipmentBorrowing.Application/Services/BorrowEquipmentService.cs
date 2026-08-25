using EquipmentBorrowing.Application.Interfaces;
using EquipmentBorrowing.Domain;

namespace EquipmentBorrowing.Application.Services;

public class BorrowEquipmentService
{
    private readonly IStudentRepository _studentRepo;
    private readonly IEquipmentRepository _equipmentRepo;
    private readonly IBorrowingRepository _borrowingRepo;

    public BorrowEquipmentService(
        IStudentRepository studentRepo,
        IEquipmentRepository equipmentRepo,
        IBorrowingRepository borrowingRepo)
    {
        _studentRepo = studentRepo;
        _equipmentRepo = equipmentRepo;
        _borrowingRepo = borrowingRepo;
    }

    public async Task<bool> ExecuteAsync(int studentId, int equipmentId)
    {
        // 1. Check student
        var student = await _studentRepo.GetByIdAsync(studentId);
        if (student == null || !student.IsEligibleToBorrow) return false;

        // 2. Check equipment
        var equipment = await _equipmentRepo.GetByIdAsync(equipmentId);
        if (equipment == null || !equipment.IsAvailable) return false;

        // 3. Check active borrowing limits
        int activeCount = await _borrowingRepo.GetActiveBorrowingCountAsync(studentId);
        if (activeCount >= student.MaxBorrowLimit) return false;

        // 4. Create and save borrowing
        var borrowing = new Borrowing(studentId, equipmentId, DateTime.UtcNow, DateTime.UtcNow.AddDays(7));
        await _borrowingRepo.AddAsync(borrowing);

        equipment.IsAvailable = false; // Update state
        return true;
    }
}