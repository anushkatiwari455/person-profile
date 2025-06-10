using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReFactor.Entity
{
    public class Person
    {
        private readonly static DateTimeOffset DefaultDob = DateTimeOffset.UtcNow.AddYears(-16);

        public string Name { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }

        public Person(string name) : this(name, DefaultDob.Date) { }

        public Person(string name, DateTime dob)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            if (dob > DateTime.UtcNow)
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dob));

            Name = name;
            DateOfBirth = dob;
        }
    }
}
