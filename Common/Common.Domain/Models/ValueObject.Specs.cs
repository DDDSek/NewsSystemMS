namespace NewsSystem.Domain.Common.Models
{
    using FluentAssertions; 
    using Xunit;

    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new TestValueObject();
            var second = new TestValueObject();

            // Act 
            var result = first == second;  // equality of the objects does it work ok

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new TestValueObject();
            var second = new TestValueObject();

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }

        private class TestValueObject : ValueObject
        {

        }
    }
}
