using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.Interface;
using ASPNETBLL.Services;
using ASPNETDAL.Context;
using Moq;

namespace NunitTest.TestServices.TestCourseSevices;

[TestFixture]
public class TestCreateCourse
{
    private ICourseServices _courseServices;
    private AppDbContext _context;
    
    [SetUp]
    public void Setup()
    {
        var mockCourseServices = new Mock<ICourseServices>();
        mockCourseServices
            .Setup(x => x.AddAsync(It.IsAny<CourseRequestDto>()))
            .ReturnsAsync(true);
        _courseServices = mockCourseServices.Object;
    }

    [Test]
    public async Task TestAddCourse_ReturnTrue()
    {
        // Arrange
        var course = new CourseRequestDto() { Title = "PHP", Credits = 234 };

        // Act
        var result = await _courseServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
    
    [Test]
    public async Task TestAddCourse_ReturnFalse1()
    {
        // Arrange
        var course = new CourseRequestDto() { Title = "", Credits = 234 }; //title = null
    
        // Act
        var result = await _courseServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
    [Test]
    public async Task TestAddCourse_ReturnFalse()
    {
        // Arrange
        var course = new CourseRequestDto()
        {
            //null
        };

        // Act
        var result = await _courseServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }

    [Test] public async Task TestAddCourse_ReturnFalseAlreadyExists()
    {
        // Arrange
        var course = new CourseRequestDto()
        {
           Title = "ASP.NET",
           Credits = 0
        };

        // Act
        var result = await _courseServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
}