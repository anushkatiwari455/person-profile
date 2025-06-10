using System;
using System.Collegctions.Generic;// REVIEW: Typo error in namespace — should be "Collections". This will fail at compile time.
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    public class People// REVIEW: Naming: "People" sounds like a collection, but this represents a single entity. Consider renaming to "Person" to follow common naming conventions.
    {

        //REVIEW: Fix indentation

        // Review: Give proper meaningful names for variables and methods in the overall code
        // REVIEW: Consider storing the age threshold (e.g., 16) in a config file or a constant defined in a settings class. 
        // This makes it easier to adjust the threshold (e.g., change to under 18) without modifying code.
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);//REVIEW: Under16 is a field, not a property so consider it start with a small letter like under16
     
        
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }

        // REVIEW: Mixing DateTimeOffset and DateTime can introduce timezone bugs — better to stick with DateTimeOffset throughout for consistency.
        // QUESTION: What is the intent of setting DOB to a default val of Under16? Should this be more explicit (e.g., CreateMinorPerson())?
     public People(string name) : this(name, Under16.Date) { }
     public People(string name, DateTime dob) {
         Name = name;
         DOB = dob;// REVIEW:  type mismatch: assigning DateTime to a DateTimeOffset property — potential issue. Consider using DateTimeOffset directly.
        }
    }
    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;
        // REVIEW:  Consider exposing this via an interface (IPeopleRepository) to follow DIP (Dependency Inversion Principle)

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
       // REVIEW:  Method name should be "GetPeople" (not "Peoples" in summary comment). Also, summary comment and return type don't match actual return value — fix both.
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name // REVIEW: Comment typo: "dandon" , it should be "random"
                    string name = string.Empty;
                    // REVIEW:  Instantiating Random inside the loop causes duplicate values due to same seed. Move Random outside the loop.
                    var random = new Random();
                    if (random.Next(0, 1) == 0)
                    {//REVIEW:  random.Next(0, 1) always returns 0 — you need random.Next(0, 2) for a 50/50 chance.

                        name = "Bob";// REVIEW: Use enums or constants for name selection; avoid hardcoded strings
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    // REVIEW: 356 days for a year seems lika a typo? this Should be 365? Also prefer AddYears for clarity: DateTime.UtcNow.AddYears(-random.Next(18, 85))
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                    // REVIEW: (Nina) Don't skip exceptions like this. Preserve stack trace using `throw new Exception("...", e)` or just use `throw;` if no additional info is needed.
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            // REVIEW:  Should be 365, a typo. Also logic is inverted — DOB >= now - 30 years means younger than 30. Use <= for "older than".
            // REVIEW: use DateTimeOffset here instead of DateTime? This might introduce timezone bugs depending on how DOB was set.
        
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);//REVIEW:  Substring result is not used — this has no effect. You should return or assign this result.
            }

            return p.Name + " " + lastName;// REVIEW: Suggest truncating the return value if it exceeds 255 characters — or throw a validation error, depending on business need.
        }
    }
}
