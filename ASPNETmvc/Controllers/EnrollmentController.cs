using ASPNETBLL.Interface;
using ASPNETmvc.Helper;
using ASPNETmvc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETmvc.Controllers;

[Authorize]
public class EnrollmentController : Controller
{
    public readonly IStudentServices _studentService;
    public readonly IMapper _mapper;
    public readonly IEnrollmentServices _enrollmentService;
    public readonly ICourseServices _courseServices;


    public EnrollmentController(IStudentServices studentService, IMapper mapper,
        IEnrollmentServices enrollmentService, ICourseServices courseServices)
    {
        _studentService = studentService;
        _enrollmentService = enrollmentService;
        _mapper = mapper;
        _courseServices = courseServices;
    }

    public async Task<IActionResult> AddNewStudent([FromRoute] int id)
    {
        var temp = _courseServices.FindById(id);
        ViewBag.getTitleCourse = temp.Result.Title;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddNewStudent([FromRoute] int id, string studentId)
    {
        try
        {
            int[] intArray = studentId.Split(new char[] { ',', ' ' , ';'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            foreach (var stuId in intArray)
            {
                if (await _enrollmentService.AddStudentToCourse(id, stuId))
                {
                    ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, $"Add new student has id = {studentId} to course!");
                }
                else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
            }
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes. Try again.");
            //ViewBag.Alerts = AlertsHelper.ShowAlert(Alerts.Danger, message: "lane Catch fix bug now");
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddUseModal(EnrollmentViewModel model)
    {
        try
        {
            if (await _enrollmentService.AddStudentToCourse(model.enrollViewModel.CourseId,
                    model.enrollViewModel.StudentId))
            {
                ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, "Add new student to course!");
            }
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes. Try again.");
            ViewBag.Alerts = AlertsHelper.ShowAlert(Alerts.Danger, message: "lane Catch fix bug now");
        }

        return RedirectToAction("Index", "Course");
    }
}