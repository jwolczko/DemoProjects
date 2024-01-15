using System.Threading.Tasks;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop.Command
{
    public class GetDataCommand : AsyncVoteAppCommandBase
    {
        public GetDataCommand(VoteViewModel viewModel, IVoteApiClient voteApiClient)
            :base(viewModel, voteApiClient)
        {            
        }


        protected async override Task ExecuteAsync(object parameter)
        {
            var voters = await ApiClient.GetVotersAsync();
            var candidates = await ApiClient.GetCandidatesAsync();

            ViewModel.Voters = new System.Collections.ObjectModel.ObservableCollection<Vote.Model.Voter>(voters);
            ViewModel.Candidates = new System.Collections.ObjectModel.ObservableCollection<Vote.Model.Candidate>(candidates);
        }
    }
}
