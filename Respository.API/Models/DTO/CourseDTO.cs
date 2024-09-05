using Respository.API.Models.Domain;

namespace Respository.API.Models.DTO
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
