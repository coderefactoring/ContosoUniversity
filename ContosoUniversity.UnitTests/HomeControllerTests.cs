using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.Controllers;
using ContosoUniversity.Domain;
using ContosoUniversity.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void AboutActionReturnsThreeEnrollmentDateGroup()
        {
            // Arrange
            var enrollmentGroup = new List<EnrollmentDateGroup> {
                new EnrollmentDateGroup { EnrollmentDate = DateTime.Now.AddYears(-5), StudentCount = 10 },
                new EnrollmentDateGroup { EnrollmentDate = DateTime.Now.AddYears(-3), StudentCount = 20 },
                new EnrollmentDateGroup { EnrollmentDate = DateTime.Now.AddYears(-1), StudentCount = 30 },
            };
            Mock<IEnrollmentRepository> repositoryMock = new Mock<IEnrollmentRepository>();
            repositoryMock.Setup(r => r.GetLatestEnrollments(It.IsAny<int>())).Returns(enrollmentGroup);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.EnrollmentRepository).Returns(repositoryMock.Object);

            var expectedCount = enrollmentGroup.Count();
            var controller = new HomeController(mockUnitOfWork.Object);

            // Act
            var result = controller.About() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.EnrollmentDateGroup>;
            var actualCount = model.Count();

            // Assert
            actualCount.Should().Be(expectedCount);
        }
    }
}
