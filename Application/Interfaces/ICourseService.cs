using Application.DTOs.Courses;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateCourseAsync(NewCourse newCourse);
        List<Course> GetAll();
        Task<Course?> UpdateCourseAsync(UpdateCourse updatedCourse);
        Task<bool> DeleteCourseAsync(int id);
        Task<Course?> GetCourseByIdAsync(int id);
    }
}
