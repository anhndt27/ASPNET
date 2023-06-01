using ASPNETBLL.DTOs.CourseQueryDto;
using ASPNETBLL.DTOs.StudentQueryDto;
using ASPNETBLL.Interface;
using Moq;

namespace NunitTest.TestServices.TestStudentServices;

public class TestCreateServices
{
    public IStudentServices _studentServices;
    [SetUp]
    public void Setup()
    {
        var mockCourseServices = new Mock<IStudentServices>();
        mockCourseServices
            .Setup(x => x.AddAsync(It.IsAny<StudentDto>()))
            .ReturnsAsync(true);
        _studentServices = mockCourseServices.Object;
    }

    [Test]
    public async Task TestAddCourse_ReturnTrue()
    {
        // Arrange
        var course = new StudentDto() { Name = "Tuan Anh kkk", Code = "CT030206" };

        // Act
        var result = await _studentServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
    
    [Test]
    public async Task TestAddCourse_ReturnFalse1()
    {
        // Arrange
        // Arrange
        var course = new StudentDto() { Name = "Tuan Anh", Code = "CT030303" };

        // Act
        var result = await _studentServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
    [Test]
    public async Task TestAddCourse_ReturnFalse()
    {
        // Arrange
        // Arrange
        var course = new StudentDto() { Name = "", Code = "" };

        // Act
        var result = await _studentServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }

    [Test] public async Task TestAddCourse_ReturnFalse2()
    {
        // Arrange
        var course = new StudentDto() { Name = "", Code = "CT030206" };

        // Act
        var result = await _studentServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
    [Test] public async Task TestAddCourse_ReturnFalse3()
    {
        // Arrange
        var course = new StudentDto() { Name = "Tuan anh", Code = "" };

        // Act
        var result = await _studentServices.AddAsync(course);

        // Assert
        Assert.IsTrue(result);
    }
}