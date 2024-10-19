using Microsoft.AspNetCore.Mvc;
using DotNetWithTCandSplunk.Model;
using DotNetWithTCandSplunk.Services;

namespace DotNetWithTCandSplunk.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("search/{RollNo}")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        public async Task<ActionResult<Student>> GetStudent(int RollNo)
        {
            var studentDetails = await _studentService.SearchStudent(RollNo);
            return Ok(studentDetails);
        }
    }
}
