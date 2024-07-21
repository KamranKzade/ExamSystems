using Application.DTOs.Exams;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IExamService
    {
        Task<bool> CreateExamAsync(NewExam newExam);
        List<Exam> GetAll();
        Task<Exam?> UpdateExamAsync(UpdateExam updatedExam);
        Task<bool> DeleteExamAsync(int id);
        Task<Exam?> GetExamByIdAsync(int id);
        Task<Exam?> MarkExamAsync(int id, int score);
    }
}
