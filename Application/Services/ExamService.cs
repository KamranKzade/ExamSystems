using Application.DTOs.Courses;
using Application.DTOs.Exams;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ExamService(IExamRepository repository, IMapper mapper) : IExamService
    {
        public async Task<bool> CreateExamAsync(NewExam newExam)
        {
            var exam = mapper.Map<Exam>(newExam);
            try
            {
                await repository.AddAsync(exam);
                await repository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            var exam = await repository.GetAsync(id);
            if (exam == null)
                return false;

            await repository.RemoveAsync(id);
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<Exam?> GetExamByIdAsync(int id) => await repository.GetAsync(id);

        public Task<Exam?> MarkExamAsync(int id, int score)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAll() => repository.GetAll().ToList();

        public async Task<Exam?> UpdateExamAsync(UpdateExam updatedExam)
        {
            var exam = await repository.GetAsync(updatedExam.Id);

            if (exam == null)
                return null;

            exam = mapper.Map(updatedExam, exam);
            repository.Update(exam);
            await repository.SaveChangesAsync();
            return exam;
        }
    }
}
