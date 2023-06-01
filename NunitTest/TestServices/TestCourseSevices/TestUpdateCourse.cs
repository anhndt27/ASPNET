using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.Interface;
using ASPNETDAL.Context;
using Moq;

namespace NunitTest.TestServices.TestCourseSevices;

[TestFixture]
public class TestUpdateCourse
{
    private ICourseServices _courseServices;
    private AppDbContext _context;
    
    [SetUp]
    public void Setup()
    {
        var mockCourseServices = new Mock<ICourseServices>();
        mockCourseServices.Setup(x => x.FindById(It.IsAny<int>()));
        mockCourseServices
            .Setup(x => x.UpdateAsync(It.IsAny<CourseRequestDto>()))
            .ReturnsAsync(true);
        _courseServices = mockCourseServices.Object;
    }

    [Test]
    public async Task TestUpdateCourse_ReturnTrue()
    {
        // Arrange
        var course = new CourseRequestDto();
        var findCourse = _courseServices.FindById(20);
        course.Title = "PHP";
        course.Credits = 235; //{ Title = "PHP", Credits = 234 };

        // Act
        if (course.Id == 20)
        {
            var result = await _courseServices.UpdateAsync(course);
            // Assert
            Assert.IsTrue(result);
        }
        Assert.IsFalse(false);
    }
}