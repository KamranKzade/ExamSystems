using Application.DTOs.Auth;
using Application.DTOs.Courses;
using Application.DTOs.Exams;
using Application.DTOs.Students;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<NewStudent, Student>();
            CreateMap<NewCourse, Course>();
            CreateMap<NewExam, Exam>();

            CreateMap<UpdateStudent, Student>();
            CreateMap<UpdateCourse, Course>();
            CreateMap<UpdateExam, Exam>();

            CreateMap<Student, UpdateStudent>();
            CreateMap<Course, UpdateCourse>();
            CreateMap<Exam, UpdateExam>();

            CreateMap<RegisterViewModel, User>();
        }
    }
}
