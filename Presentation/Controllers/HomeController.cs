using Application.DTOs.Courses;
using Application.DTOs.Exams;
using Application.DTOs.Students;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using System.Diagnostics;

namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController(IStudentService studentService, IMapper mapper, ICourseService courseService, IExamService examService) : Controller
    {

        public IActionResult Index() => View(studentService.GetAll());

        public IActionResult Courses() => View(courseService.GetAll());

        public IActionResult Exams() => View(examService.GetAll());

        public IActionResult AddExam()
        {
            ViewBag.StudentNumbers = new SelectList(studentService.GetAll(), "StudentNumber", "StudentNumber");
            ViewBag.CourseCodes = new SelectList(courseService.GetAll(), "CourseCode", "CourseCode");
            return View();
        }

        public IActionResult AddCourse() => View();


        public IActionResult AddStudent() => View();


        [HttpPost]
        public async Task<IActionResult> AddStudent(NewStudent model)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                if (ModelState.IsValid)
                {
                    var result = await studentService.CreateStudentAsync(model);
                    if (result)
                        return RedirectToAction("Index");

                    ModelState.AddModelError("StudentNumber", "Number must be unique");
                    return View(model);
                }
                return View("Error", new ErrorViewModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(NewCourse model)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                if (ModelState.IsValid)
                {
                    var result = await courseService.CreateCourseAsync(model);
                    if (result)
                        return RedirectToAction("Courses");
                    ModelState.AddModelError("CourseCode", "Code must be unique");
                    return View(model);
                }
                return View("Error", new ErrorViewModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(NewExam model)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                if (ModelState.IsValid)
                {
                    await examService.CreateExamAsync(model);
                    return RedirectToAction("Exams");
                }
                return View("Error", new ErrorViewModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await studentService.DeleteStudentAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await courseService.DeleteCourseAsync(id);

                return RedirectToAction("Courses");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> DeleteExam(int id)
        {
            try
            {
                await examService.DeleteExamAsync(id);

                return RedirectToAction("Exams");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> EditStudentAsync(int id)
        {
            try
            {
                var student = await studentService.GetStudentByIdAsync(id);
                if (student is not null)
                {
                    var model = mapper.Map<UpdateStudent>(student);
                    ViewBag.Id = id;
                    return View(model);
                }
                return View("Error", new ErrorViewModel());

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> EditCourseAsync(int id)
        {
            try
            {
                var course = await courseService.GetCourseByIdAsync(id);
                if (course is not null)
                {
                    var model = mapper.Map<UpdateCourse>(course);
                    ViewBag.Id = id;
                    return View(model);
                }
                return View("Error", new ErrorViewModel());

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public async Task<IActionResult> EditExamAsync(int id)
        {
            try
            {
                var exam = await examService.GetExamByIdAsync(id);
                if (exam is not null)
                {
                    var model = mapper.Map<UpdateExam>(exam);
                    ViewBag.StudentNumbers = new SelectList(studentService.GetAll(), "StudentNumber", "StudentNumber");
                    ViewBag.CourseCodes = new SelectList(courseService.GetAll(), "CourseCode", "CourseCode");
                    ViewBag.Id = id;
                    return View(model);
                }
                return View("Error", new ErrorViewModel());

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExam(UpdateExam model, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = id;
                    await examService.UpdateExamAsync(model);

                    return RedirectToAction("Exams");
                }
                return View("Error", new ErrorViewModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(UpdateStudent model, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = id;
                    await studentService.UpdateStudentAsync(model);

                    return RedirectToAction("Index");
                }
                return RedirectToAction("EditStudent", model);
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourse model, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = id;
                    await courseService.UpdateCourseAsync(model);

                    return RedirectToAction("Courses");
                }
                return View("Error", new ErrorViewModel());
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());

            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
