using ReFactor.Configuration;
using ReFactor.Entity;
using ReFactor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class PersonServiceTests
    {
        private readonly IPersonConfig _config;
        private readonly Random _fixedRandom;

        public PersonServiceTests()
        {
            _config = new PersonConfig();
            _fixedRandom = new Random(42); // deterministic for consistent tests
        }

        [Fact]
        public void GeneratePeople_WithZeroCount_ReturnsEmptyList()
        {
            var service = new PersonService(_config, _fixedRandom);
            var people = service.GeneratePeople(0);
            Assert.Empty(people);
        }

        [Fact]
        public void GeneratePeople_WithNegativeCount_ThrowsException()
        {
            var service = new PersonService(_config);
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GeneratePeople(-1));
        }

        [Fact]
        public void GeneratePeople_ReturnsCorrectNumberOfPeople()
        {
            var service = new PersonService(_config, _fixedRandom);
            var people = service.GeneratePeople(5);
            Assert.Equal(5, people.Count);
        }

        [Fact]
        public void GetBobs_WhenOlderThanConfiguredAge_ReturnsCorrectSubset()
        {
            var service = new PersonService(_config, new Random(1));
            service.GeneratePeople(50);
            var bobs = service.GetBobs(true);
            Assert.All(bobs, p => Assert.Equal("Bob", p.Name));
        }

        [Fact]
        public void GetMarried_WithNullLastName_ReturnsOriginalName()
        {
            var service = new PersonService(_config);
            var person = new Person("Alice", DateTime.UtcNow.AddYears(-30));
            var name = service.GetMarried(person, null);
            Assert.Equal("Alice", name);
        }

        [Fact]
        public void GetMarried_WithDisallowedSubstring_ReturnsOriginalName()
        {
            var service = new PersonService(_config);
            var person = new Person("John", DateTime.UtcNow.AddYears(-40));
            var name = service.GetMarried(person, "testcase");
            Assert.Equal("John", name);
        }

        [Fact]
        public void GetMarried_WithValidLastName_ReturnsFullName()
        {
            var service = new PersonService(_config);
            var person = new Person("Jane", DateTime.UtcNow.AddYears(-35));
            var name = service.GetMarried(person, "Smith");
            Assert.Equal("Jane Smith", name);
        }

        [Fact]
        public void GetMarried_NameExceedsMaxLength_IsTrimmed()
        {
            var service = new PersonService(_config);
            var person = new Person(new string('A', 250), DateTime.UtcNow.AddYears(-25));
            var lastName = new string('B', 10); // makes 260
            var name = service.GetMarried(person, lastName);
            Assert.Equal(255, name.Length);
        }
    }

}
