using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Moldel;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for deleting a PersonVO from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        // Method responsible for returning all people,
        // again this information is mocks
        public List<PersonVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());
        }

        // Method responsible for returning a PersonVO
        // as we have not accessed any database we are returning a mock
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        
        // Method responsible for updating a PersonVO for
        // being mock we return the same information passed
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}