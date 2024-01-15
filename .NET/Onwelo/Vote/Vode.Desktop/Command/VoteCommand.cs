using System.Threading.Tasks;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop.Command
{
    public class VoteCommand : AsyncVoteAppCommandBase
    {
        public VoteCommand(VoteViewModel viewModel, IVoteApiClient apiClient)
            : base(viewModel, apiClient) { }        

        protected override Task ExecuteAsync(object parameter)
        {
            var vote = new Vote.Model.Vote
            {
                Voter = ViewModel.SelectedVoter,
                Candidate= ViewModel.SelectedCandidate
            };

            return ApiClient.PostVoteAsync(vote)
                .ContinueWith(t => { 
                ViewModel.GetDataCommand.Execute(null);
            });
        }
    }
}
