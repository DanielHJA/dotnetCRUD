using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
}