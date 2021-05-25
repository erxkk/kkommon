using System;

using Xunit;

namespace Kkommon.UnitTests
{
    public sealed class OptionalTests
    {
        [Fact]
        public void Throws_If_Not_Set_Explicitly()
        {
            // The Optional will not return a default value if it isn't explicitly set
            Optional<string> unsetOptional = Optional.Empty<string>();

            // returns false because it was created as empty
            Assert.False(unsetOptional.HasValue);

            // throws as no value was explicitly set
            Assert.Throws<InvalidOperationException>(() => unsetOptional.Value);
        }

        [Fact]
        public void Allows_Default_If_Set_Explicitly()
        {
            // The Optional will allow a default value if it is explicitly set
            Optional<string> setOptional = Optional.FromValue<string>(null!);

            // returns is set because it was explicitly set
            Assert.True(setOptional.HasValue);

            // returns value without throwing because it was explicitly set
            Assert.Null(setOptional.Value);
        }

        [Fact]
        public void ToNullable_Unambiguous()
        {
            Optional<string> unsetStringOptional = Optional.Empty<string>();
            Optional<int> unsetIntOptional = Optional.Empty<int>();

            // both ref and value type optionals can return with ToNullable through the power of Extensions
            string? nullableString = unsetStringOptional.ToNullable();
            int? nullableInt = unsetIntOptional.ToNullable();
        }
    }
}