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

    public StudentController(IStudentServices studentService)
    {
        _studentService = studentService;
    }
    // GET
    //[HttpGet("/Student/Index")]
    public async Task<IActionResult> Index(string sortOrder,string searchString,string currentFilter,int? pageNumber, bool deleteFlag = false)
    {
        try
        {
            if (deleteFlag) ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success, message: "Remove student success!");
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CodeSortParm"] = sortOrder == "Code" ? "code_desc" : "Code";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            //var listService = new ListStudentServices(_context);
            var res = await _studentService.GetListAsync(sortOrder,searchString,currentFilter,pageNumber);
            int pageSize = 5;
            var resault =await Paging<StudentDto>.CreateAsync(res,pageNumber ?? 1, pageSize);
            return View(resault);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
        catch (Exception e)
        {
            ModelState.AddModelError("",
                "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            Console.WriteLine(e);
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