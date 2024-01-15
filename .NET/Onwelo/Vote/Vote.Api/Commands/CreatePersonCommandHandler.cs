using MediatR;
using Vote.Data;
using Vote.Data.Entities;

namespace Vote.Api.Commands
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly VoteDb _context;

        public CreatePersonCommandHandler(VoteDb context)
        {
            _context = context;
        }

        public Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newPerson = new Person 
                { 
                    FirstName = request.Person.FirstName, 
                    LastName = request.Person.LastName, 
                    Type = request.Person.Type == Model.PersonType.Candidate? PersonType.Candidate: PersonType.Voter 
                };

                _context.Persons.Add(newPerson);

                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
