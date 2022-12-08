using FluentAssertions;
using MNE.FluentValidation.Test.Models;
using MNE.FluentValidation.Test.Validators;
using NUnit.Framework;

namespace MNE.FluentValidation.Test.Tests
{
    public class CustomFluentValidatorTests
    {
        private FileUploadModelValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FileUploadModelValidator();
        }

        [Test]
        public void ShouldFailValidation()
        {
            // Arrange
            var model = new FileUploadModel
            {
                Data = "nodgdtbase64encoded"
            };

            // Act
            var result = _sut.Validate(model);

            // Assert
            result.Errors.Should().HaveCount(1);
        }

        [Test]
        public void ShouldPassValidation()
        {
            // Arrange
            var model = new FileUploadModel
            {
                Data = "aSdtYmFzZTY0ZW5jb2RlZA=="
            };

            // Act
            var result = _sut.Validate(model);

            // Assert
            result.Errors.Should().BeEmpty();
        }
    }
}
