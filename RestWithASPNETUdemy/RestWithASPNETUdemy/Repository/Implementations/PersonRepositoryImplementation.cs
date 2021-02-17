using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Moldel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        // Counter responsible for generating a fake ID
        // since we are not accessing any database
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        // Method responsible for creating a new person.
        // If we had a database this would be the time to persist the data
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // Method responsible for returning all people,
        // again this information is mocks
        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

        // Method responsible for returning a person
        // as we have not accessed any database we are returning a mock
        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        
        // Method responsible for updating a person for
        // being mock we return the same information passed
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}