using System;
using Xunit;
using Xunit.Sdk;

namespace Fluent.Dates.Tests
{
    public class GeneratorTests
    {
        private readonly IDateGenerator dateGenerator;

        public GeneratorTests() => this.dateGenerator = new DateGenerator();

        [Fact]
        public void TestEasterSunday2018()
        {
            throw new XunitException("TODO: Test Easter Sunday");
        }

        [Fact]
        public void TestChristmas2018()
        {
            Assert.Equal(new DateTime(2018, 12, 24), this.dateGenerator.Christmas(2018));
        }
    }
}
