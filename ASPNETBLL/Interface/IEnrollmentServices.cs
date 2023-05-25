namespace ASPNETBLL.Interface;

public interface IEnrollmentServices
{
    Task<bool> AddStudentToCourse(int couresId, int studentId);
}