using DotNetWithTCandSplunk.Model;

namespace DotNetWithTCandSplunk.Services
{

    public interface IStudentService
    {
        Task<List<Student>> SearchStudent(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly List<Student> _student;
        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _student = new List<Student>
            {
                new Student { Id = 1, Name = "test1", Description = "testDesc1" },
                new Student { Id = 2, Name = "test1", Description = "testDesc1" },
                new Student { Id = 3, Name = "test1", Description = "testDesc1" },
                new Student { Id = 4, Name = "test1", Description = "testDesc1" }
            };
        }

        public Task<List<Student>> SearchStudent(int studentId)
        {
            _logger.LogInformation($"Student serach started for student Id: {studentId}");
            var studentsDetails = _student.Where(e => e.Id == studentId).ToList();
            if (studentsDetails.Any())
            {
                _logger.LogInformation($"Data retrived successfully for student Id: {studentId}");
                return Task.FromResult(studentsDetails);
            }

            return Task.FromResult(studentsDetails);
        }
    }
}
