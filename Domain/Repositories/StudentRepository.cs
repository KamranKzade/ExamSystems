using Domain.Contexts;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class StudentRepository(AppDbContext context) : Repository<Student>(context), IStudentRepository
    {
    }
}
