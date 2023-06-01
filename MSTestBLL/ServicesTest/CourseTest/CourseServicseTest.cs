using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using ASPNETDAL.Context;
using Moq;

namespace MSTestBLL.ServicesTest.CourseTest;

[TestClass]
public class CourseServicseTest
{
    private Mock<ICourseServices> _mockcourseServices;
    public ICourseServices _courseServices;
    public CourseServicseTest(ICourseServices courseServices)
    {
        _courseServices = courseServices;
    }
    
    [TestInitialize]
    public void Initialize()
    {
        
    }

    public void TestGetListCourse()
    {
        
    }
}