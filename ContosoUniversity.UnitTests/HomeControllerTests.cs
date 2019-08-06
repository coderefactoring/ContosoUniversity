using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.Controllers;
using ContosoUniversity.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void AboutActionReturnsFiveEnrollmentDateGroup()
        {
            // Arrange
            var expectedCount = 5;
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;
            var model = result.Model as IEnumerable<EnrollmentDateGroup>;
            var actualCount = model.Count();

            // Assert
            actualCount.Should().Be(expectedCount);
        }
    }
}
