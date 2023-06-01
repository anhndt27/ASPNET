using ASPNETBLL.Interface;

namespace NunitTest;

[TestFixture]
public class Tests
{
    public ICourseServices _courseServices;
    [SetUp]
    public void Setup(ICourseServices courseServices)
    {
        _courseServices = courseServices;
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}