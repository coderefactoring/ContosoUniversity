﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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
                new EnrollmentDateGroup(),
                new EnrollmentDateGroup(),
                new EnrollmentDateGroup(),
            };

            var enrollmentGroupVM = new List<ViewModels.EnrollmentDateGroupVM> {
                new ViewModels.EnrollmentDateGroupVM(),
                new ViewModels.EnrollmentDateGroupVM(),
                new ViewModels.EnrollmentDateGroupVM(),
            };

            Mock<IEnrollmentRepository> repositoryMock = new Mock<IEnrollmentRepository>();
            repositoryMock
                .Setup(r => r.GetEnrollments())
                .Returns(enrollmentGroup);

            Mock<IMapper> mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(m => m.Map<IEnumerable<ViewModels.EnrollmentDateGroupVM>>(It.IsAny<IEnumerable<EnrollmentDateGroup>>()))
                .Returns(enrollmentGroupVM);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Enrollments)
                .Returns(repositoryMock.Object);

            var expectedCount = enrollmentGroup.Count();
            var controller = new HomeController(mockUnitOfWork.Object, mapperMock.Object);

            // Act
            var result = controller.About() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.EnrollmentDateGroupVM>;
            var actualCount = model.Count();

            // Assert
            actualCount.Should().Be(expectedCount);
        }
    }
}
