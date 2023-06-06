using ASPNETBLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETapiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentApiController : ControllerBase
    {
        public readonly IEnrollmentServices _enrollmentServices;

        public EnrollmentApiController(IEnrollmentServices enrollmentServices)
        {
            _enrollmentServices = enrollmentServices;
        }
        [HttpPost]
        public async Task<bool> AddNewStudent(int id,[FromBody] string studentId)
        {
            try
            {
                int[] intArray = studentId.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                foreach (var stuId in intArray)
                {
                    if (await _enrollmentServices.AddStudentToCourse(id, stuId))
                    {
                        /*ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Success,
                            $"Add new student has id = {studentId} to course!");*/
                    }
                    //else ViewBag.Alert = AlertsHelper.ShowAlert(Alerts.Danger, "Unknown error");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
                //ViewBag.Alerts = AlertsHelper.ShowAlert(Alerts.Danger, message: "lane Catch fix bug now");
            }
            return true;
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> AddUseModal(EnrollmentViewModel model)
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
        }*/
    }
}