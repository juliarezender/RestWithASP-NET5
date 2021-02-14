using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Moldel;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        // Counter responsible for generating a fake ID
        // since we are not accessing any database
        private IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        // Method responsible for creating a new person.
        // If we had a database this would be the time to persist the data
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        // Method responsible for returning all people,
        // again this information is mocks
        public List<Person> FindAll()
        {

            return _repository.FindAll();
        }

        // Method responsible for returning a person
        // as we have not accessed any database we are returning a mock
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }
        
        // Method responsible for updating a person for
        // being mock we return the same information passed
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}