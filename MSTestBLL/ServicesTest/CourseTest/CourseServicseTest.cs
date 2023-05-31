using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using ASPNETDAL.Context;
using Moq;

namespace MSTestBLL.ServicesTest.CourseTest;

[TestClass]
public class CourseServicseTest
{
    private Mock<ICourseServices> _mockcourseServices;

    public CourseServicseTest()
    {
        //_courseServices = new CourseServices();
    }
    
    [TestInitialize]
    public void Initialize()
    {
        
    }
}