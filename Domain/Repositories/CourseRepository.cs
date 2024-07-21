using Domain.Contexts;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class CourseRepository(AppDbContext context) : Repository<Course>(context), ICourseRepository
    {
    }
}
