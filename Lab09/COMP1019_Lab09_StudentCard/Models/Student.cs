namespace COMP1019_Lab09_StudentCard.Models;

public class Student
{
    public string StudentId { get; set; }
    public string FullName { get; set; }
    public string Class { get; set; }
    public string Faculty { get; set; }
    public string Course { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Image? Photo { get; set; }

    public Student()
    {
        StudentId = string.Empty;
        FullName = string.Empty;
        Class = string.Empty;
        Faculty = string.Empty;
        Course = string.Empty;
        DateOfBirth = DateTime.Now;
        Gender = string.Empty;
        Photo = null;
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(StudentId) &&
               !string.IsNullOrWhiteSpace(FullName) &&
               Photo != null;
    }
}
