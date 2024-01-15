using System.Threading.Tasks;
using Vode.Desktop.DialogWindow;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;
using Vote.Model;

namespace Vode.Desktop.Command
{
    public class AddPersonCommand : AsyncVoteAppCommandBase
    {
        private PersonType PersonType { get; init; }

        public AddPersonCommand(VoteViewModel viewModel, IVoteApiClient voteApiClient, PersonType personType)
            : base(viewModel, voteApiClient) => PersonType = personType;
        
        protected override Task ExecuteAsync(object parameter)
        {
            Person newPerson = PersonType == PersonType.Candidate? new Candidate() : new Voter();
            var addPersonDialog = new AddPerson(newPerson);
            var dialogResult =  addPersonDialog.ShowDialog();

            if(!dialogResult.HasValue || !dialogResult.Value)
                return Task.CompletedTask;

            Task addPersonTask;

            if(PersonType == PersonType.Candidate)
            {
                addPersonTask = ApiClient.PostCandidateAsync(newPerson as Candidate);
            }
            else
            {
                addPersonTask = ApiClient.PostVoterAsync(newPerson as Voter);
            }

            return addPersonTask.ContinueWith(t =>
            {
                ViewModel.GetDataCommand.Execute(null);
            });                
        }
    }
}
