using Application.DTOs.Courses;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CourseService(ICourseRepository repository, IMapper mapper) : ICourseService
    {
        public async Task<bool> CreateCourseAsync(NewCourse newCourse)
        {
            var course = mapper.Map<Course>(newCourse);
            try
            {
                await repository.AddAsync(course);
                await repository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await repository.GetAsync(id);
            if (course == null)
                return false;

            await repository.RemoveAsync(id);
            await repository.SaveChangesAsync();
            return true;
        }

        public List<Course> GetAll() => repository.GetAll().ToList();

        public async Task<Course?> GetCourseByIdAsync(int id) => await repository.GetAsync(id);

        public async Task<Course?> UpdateCourseAsync(UpdateCourse updatedCourse)
        {
            var course = await repository.GetAsync(updatedCourse.Id);

            if (course == null)
                return null;

            course = mapper.Map(updatedCourse, course);
            repository.Update(course);
            await repository.SaveChangesAsync();
            return course;
        }
    }
}
