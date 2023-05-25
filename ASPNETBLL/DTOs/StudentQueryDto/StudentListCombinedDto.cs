using ASPNETBLL.DTOs.Filter;

namespace ASPNETBLL.DTOs.StudentQueryDto;

public class StudentListCombinedDto
{
    public class StudentListCombinedDTO
    {
        public SortFilterPageOptions sortFiltePageData { get; private set; }
        public IEnumerable<StudentDto> StudentList { get; private set; }
        public StudentListCombinedDTO(SortFilterPageOptions option, IEnumerable<StudentDto> studentList)
        {
            sortFiltePageData = option;
            StudentList = studentList;
        }
    }
}