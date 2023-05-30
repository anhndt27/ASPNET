using ASPNETBLL.DTOs.Filter;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using ASPNETmvc.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETmvc.Controllers;

public class StudentController : Controller
{
    public readonly IStudentServices _studentService;

    public readonly IMapper _mapper;

    // GET
    //[HttpGet("/Student/Index")]
    public async Task<IActionResult> Index(SortFilterPageOptions options, bool deleteFlag = false)
    {
        if (deleteFlag) ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, message: "remove Student success");
        var res = await _studentService.GetListSortAsync(options);
        return View(res);
    }

    // GET: UserManagerController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var UserProfile = await _studentService.GetByIdAsync(id);
        return View(UserProfile);
    }

    // GET: UserManagerController/Create

    public ActionResult Create()
    {
        return View(new StudentDto());
    }

    // POST: UserManagerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentDto entity)
    {
        try
        {
            if (await _studentService.AddAsync(entity))
            {
                ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, "Create Ok!");
            }
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
            //return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError("",
                "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        }

        return View(entity);
    }

    // GET: UserManagerController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var res = await _studentService.GetByIdAsync(id);
        return View(res);
    }

    // POST: UserManagerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(StudentDto entity)
    {
        try
        {
            if (await _studentService.UpdateAsync(entity))
            {
                ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, "Update Ok!");
            }
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
            //return RedirectToAction(nameof(Index));
        }
        catch

        {
            ModelState.AddModelError("",
                "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        }

        return View();
    }

// GET: UserManagerController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var res = await _studentService.GetByIdAsync(id);
        return View(res);
    }

// POST: UserManagerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(StudentDto entity)
    {
        try
        {
            if (await _studentService.DeleteAsync(entity))
            {
                return RedirectToAction(nameof(Index), new { deleteFlag = true });
            }
            else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Remove faile");
        }
        catch (InvalidDataException)
        {
            return View();
        }

        return View();
    }
}