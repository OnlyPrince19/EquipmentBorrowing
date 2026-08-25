using EquipmentBorrowing.Application.Services;
using EquipmentBorrowing.Infrastructure.Repositories;

var studentRepo = new InMemoryStudentRepository();
var equipmentRepo = new InMemoryEquipmentRepository();
var borrowingRepo = new InMemoryBorrowingRepository();

var service = new BorrowEquipmentService(studentRepo, equipmentRepo, borrowingRepo);

Console.WriteLine("=== Equipment Borrowing System ===");

bool result1 = await service.ExecuteAsync(studentId: 1, equipmentId: 1);
Console.WriteLine($"Student 1 borrowing Equipment 1: {(result1 ? "SUCCESS" : "FAILED")}");

bool result2 = await service.ExecuteAsync(studentId: 2, equipmentId: 2);
Console.WriteLine($"Student 2 borrowing Equipment 2: {(result2 ? "SUCCESS" : "FAILED")}");

bool result3 = await service.ExecuteAsync(studentId: 1, equipmentId: 2);
Console.WriteLine($"Student 1 borrowing Equipment 2 (already unavailable): {(result3 ? "SUCCESS" : "FAILED")}");

Console.WriteLine("Done. Press any key to exit.");
Console.ReadKey();