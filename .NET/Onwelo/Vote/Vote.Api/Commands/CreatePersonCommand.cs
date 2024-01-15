using MediatR;
using Vote.Model;

namespace Vote.Api.Commands
{
    public class CreatePersonCommand:IRequest
    {
        public Person Person { get; set; }
    }
}
