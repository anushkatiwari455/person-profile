using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReFactor.Configuration;
using ReFactor.Entity;

namespace ReFactor.Service
{
    public class PersonService
    {
        private readonly List<Person> _people;
        private readonly Random _random;
        private readonly IPersonConfig _config;

        public PersonService(IPersonConfig config, Random random = null)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _random = random ?? new Random();
            _people = new List<Person>();
        }

        public List<Person> GeneratePeople(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");

            for (int i = 0; i < count; i++)
            {
                try
                {
                    var name = GetRandomName();

                    int age = _random.Next(_config.MinimumAge, _config.MaximumAge + 1);
                    DateTime dob = DateTime.UtcNow.AddYears(-age);

                    var person = new Person(name, dob);
                    _people.Add(person);
                }
                catch (Exception ex)
                {
                    // Logging can be added here
                    throw new InvalidOperationException("Error occurred while generating person.", ex);
                }
            }

            return _people;
        }

        public IEnumerable<Person> GetBobs(bool olderThanConfiguredAge)
        {
            try
            {
                var cutoff = DateTime.UtcNow.AddYears(-_config.AgeForFilter);
                return olderThanConfiguredAge
                    ? _people.Where(p => p.Name == "Bob" && p.DateOfBirth <= cutoff)
                    : _people.Where(p => p.Name == "Bob");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve 'Bob' records.", ex);
            }
        }

        public string GetMarried(Person person, string lastName)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            if (string.IsNullOrWhiteSpace(lastName))
                return person.Name;

            if (lastName.Contains(_config.DisallowedLastNameSubstring, StringComparison.OrdinalIgnoreCase))
                return person.Name;

            try
            {
                var fullName = $"{person.Name} {lastName}";
                return fullName.Length > _config.MaxNameLength
                    ? fullName.Substring(0, _config.MaxNameLength)
                    : fullName;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to construct full name.", ex);
            }
        }

        private string GetRandomName()
        {
            if (_config.NamesPool == null || _config.NamesPool.Length == 0)
                throw new InvalidOperationException("NamesPool is not properly configured.");

            int index = _random.Next(0, _config.NamesPool.Length);
            return _config.NamesPool[index];
        }
    }
}
