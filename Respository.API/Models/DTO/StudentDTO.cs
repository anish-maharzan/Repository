using Respository.API.Models.Domain;

namespace Respository.API.Models.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
