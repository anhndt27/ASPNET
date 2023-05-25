using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.EnrollmentQueryDto;
using ASPNETBLL.Interface;
using ASPNETmvc.Helper;
using ASPNETmvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETmvc.Controllers;

public class CourseController : Controller
{
    // GET
    public readonly ICourseServices _courseServices;

    public CourseController(ICourseServices courseServices)
    {
        _courseServices = courseServices;
    }

    //
    // GET: CourseController
    public async Task<IActionResult> Index(bool deleteFlag = false)
    {
        if (deleteFlag) ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, message: " remove Course");
        var courseList = await _courseServices.GetListCourseStudentAsync();
        var courseViewModel = new CourseDto();
        var enrollViewModel = new CourseRequestDto();
        var viewmodel = new EnrollmentViewModel()
        {
            courseViewModel = courseList,
            enrollViewModel = new EnrollmentCreateDto()
        };
        return View(viewmodel);
    }

    // GET: CourseController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var res = await _courseServices.GetByIdAsync(id);
        return View(res);
    }

    // GET: CourseController/Create
    public async Task<IActionResult> Create()
    {
        return View(new CourseRequestDto());
    }

    // POST: CourseController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseRequestDto entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (await _courseServices.AddAsync(entity))
                {
                    ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, "Create Ok!");
                }
                else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
                //return RedirectToAction(nameof(Index));
            }
        }
        catch
        {
            return View();
        }

        return View(entity);
    }

    // GET: CourseController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var res = await _courseServices.FindById(id);
        return View(res);
    }

    // POST: CourseController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CourseRequestDto entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (await _courseServices.UpdateAsync(entity))
                {
                    ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, "Update Ok!");
                }
                else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
                //return RedirectToAction(nameof(Index));
            }
        }
        catch
        {
            ModelState.AddModelError("",
                "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        }

        return View(entity);
    }

    // GET: CourseController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _courseServices.FindById(id);
        return View(res);
    }

    // POST: CourseController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(CourseRequestDto entity)
    {
        try
        {
            if (await _courseServices.DeleteAsync(entity))
            {
                return RedirectToAction(nameof(Index), new { deleteFlag = true });
            }
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Remove faile");
        }
        catch
        {
            return View();
        }

        return View();
    }
}