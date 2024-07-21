using Application.DTOs.Courses;
using Application.DTOs.Students;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class StudentService(IStudentRepository repository, IMapper mapper) : IStudentService
    {
        public async Task<bool> CreateStudentAsync(NewStudent newStudent)
        {
            var student = mapper.Map<Student>(newStudent);
            try
            {
                await repository.AddAsync(student);
                await repository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await repository.GetAsync(id);
            if (student == null)
                return false;

            await repository.RemoveAsync(id);
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> GetStudentByIdAsync(int id) => await repository.GetAsync(id);

        public List<Student> GetAll() => repository.GetAll().ToList();

        public async Task<Student?> UpdateStudentAsync(UpdateStudent updatedStudent)
        {
            var student = await repository.GetAsync(updatedStudent.Id);

            if (student == null)
                return null;

            student = mapper.Map(updatedStudent, student);
            repository.Update(student);
            await repository.SaveChangesAsync();
            return student;
        }
    }
}
