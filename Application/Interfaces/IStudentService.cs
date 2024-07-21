using Application.DTOs.Students;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<bool> CreateStudentAsync(NewStudent newStudent);
        List<Student> GetAll();
        Task<Student?> UpdateStudentAsync(UpdateStudent updatedStudent);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student?> GetStudentByIdAsync(int id);
    }
}
