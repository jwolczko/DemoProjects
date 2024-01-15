using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop.Command
{
    public abstract class AsyncVoteAppCommandBase: AsyncCommandBase
    {
        protected VoteViewModel ViewModel { get; init; }
        protected IVoteApiClient ApiClient { get; init; }

        protected AsyncVoteAppCommandBase(VoteViewModel viewModel, IVoteApiClient voteApiClient)
        {
            ViewModel = viewModel;
            ApiClient = voteApiClient;
        }
    }
}
