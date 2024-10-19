using AutoFixture;
using DotNetWithTCandSplunk.Controllers;
using DotNetWithTCandSplunk.Model;
using DotNetWithTCandSplunk.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace DotNetWithTCandSplunk.Controller
{
    public class StudentControllerTests
    {
        private readonly IStudentService _studentService;
        private readonly StudentController _controller;
        private readonly Fixture _fixture;

        public StudentControllerTests()
        {
            _studentService = Substitute.For<IStudentService>();
            _controller = new StudentController(_studentService);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetStudent_ReturnsOkResult_WhenStudentIsFound()
        {
            // Arrange
            int rollNo = 1;
            var student = new Student { Id = rollNo, Name = "John Doe" }; // Example student object
            
            var studentList = _fixture.Create<List<Student>>();

            _studentService.SearchStudent(rollNo).Returns(studentList);

            // Act
            var result = await _controller.GetStudent(rollNo);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Student>>(okResult.Value);
            returnValue.Should().NotBeNull();
        }

        //[Fact]
        //public async Task GetStudent_ReturnsNotFound_WhenStudentIsNotFound()
        //{
        //    // Arrange
        //    var rollNo = "456";
        //    _controller.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = new DefaultHttpContext()
        //    };
        //    _controller.HttpContext.Request.Headers["RollNo"] = rollNo;

        //    var exception = await Assert.ThrowsAsync<NotFoundException>(() => _studentService.SearchStudent(rollNo));

        //}
    }
}
