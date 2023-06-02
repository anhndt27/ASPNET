using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.EnrollmentQueryDto;
using ASPNETBLL.Interface;
using ASPNETmvc.Helper;
using ASPNETmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETmvc.Controllers;

[Authorize]
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
        try
        {
            if (deleteFlag)
                ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, message: "Remove Course successful!");
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, message: "Can't show all course, error out!");
            return View();
            //throw;
        }

        return View();
    }

    // GET: CourseController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var res = await _courseServices.GetByIdAsync(id);
            return View(res);
        }
        catch (Exception e)
        {
            ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, message: "Can't find course, error out!");
            Console.WriteLine(e);
            throw;
        }
    }

    // GET: CourseController/Create
    public async Task<IActionResult> Create()
    {
        try
        {
            return View(new CourseRequestDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
                else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, $"Error");
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("",
                $"Unable to save changes. Course is already exist!");
            Console.WriteLine(e);
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
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("",
                $"Unable to save changes. Course is already exist!");
            Console.WriteLine(e);
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
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Remove fail!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return View();
        }

        return View();
    }
}