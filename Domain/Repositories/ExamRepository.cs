using Domain.Contexts;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class ExamRepository(AppDbContext context) : Repository<Exam>(context), IExamRepository
    {
    }
}
