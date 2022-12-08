using FluentValidation.TestHelper;
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

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ShouldFailValidationGivenNullOrEmpty(string data)
        {
            // Arrange
            var model = new FileUploadModel
            {
                Data = data
            };

            // Act
            var result = _sut.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Data).WithErrorMessage("Data is not a valid base64 value.");
        }

        [Test]
        public void ShouldFailValidationGivenInvalidString()
        {
            // Arrange
            var model = new FileUploadModel
            {
                Data = "notbase64encoded"
            };

            // Act
            var result = _sut.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Data).WithErrorMessage("Data is not a valid base64 value.");
        }

        [Test]
        public void ShouldPassValidationGivenBase64EncodedString()
        {
            // Arrange
            var model = new FileUploadModel
            {
                Data = "aSdtYmFzZTY0ZW5jb2RlZA=="
            };

            // Act
            var result = _sut.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Data);
        }
    }
}
