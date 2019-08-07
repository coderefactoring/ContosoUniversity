using AutoMapper;
using ContosoUniversity.Controllers;
using ContosoUniversity.Domain;
using ContosoUniversity.Interfaces;
using ContosoUniversity.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class StudentControllerTests
    {
        [TestMethod]
        public void IndexActionReturnsMatchingCountStudentVM()
        {
            // Arrange
            var students = new List<Student>() {
                new Student { FirstMidName = "Zia", LastName = "Khan", EnrollmentDate = DateTime.Now }
            };

            var studentsVM = new List<StudentVM>() {
                new StudentVM { FirstName = "Zia", LastName = "Khan", EnrollmentDate = DateTime.Now.ToShortDateString() }
            };

            Mock<IStudentRepository> repositoryMock = new Mock<IStudentRepository>();
            repositoryMock
                .Setup(r => r.Find(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(students);

            Mock<IMapper> mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(m => m.Map<IEnumerable<StudentVM>>(It.IsAny<IEnumerable<Student>>()))
                .Returns(studentsVM);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Students)
                .Returns(repositoryMock.Object);

            var expectedCount = 1;
            var controller = new StudentController(mockUnitOfWork.Object, mapperMock.Object);

            // Act
            var result = controller.Index("Z") as ViewResult;
            var model = result.Model as IEnumerable<StudentVM>;
            var actualCount = model.Count();

            // Assert
            actualCount.Should().Be(expectedCount);
        }
    }
}
