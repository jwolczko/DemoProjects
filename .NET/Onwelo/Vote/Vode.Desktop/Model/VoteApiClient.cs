using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Vote.Model;

namespace Vode.Desktop.Model
{
    public interface IVoteApiClient
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync();
        Task<IEnumerable<Voter>> GetVotersAsync();
        Task PostCandidateAsync(Candidate candidate);
        Task PostVoteAsync(Vote.Model.Vote vote);
        Task PostVoterAsync(Voter voter);
    }

    public class VoteApiClient : IVoteApiClient
    {
        private string _baseApiHost;
        public VoteApiClient()
        {
            _baseApiHost = ConfigurationManager.AppSettings["baseApiHost"];
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            var candidates = await _baseApiHost.AppendPathSegments("api", "candidates")
                .GetJsonAsync<List<Candidate>>();

            return candidates;
        }

        public async Task<IEnumerable<Voter>> GetVotersAsync()
        {
            var candidates = await _baseApiHost.AppendPathSegments("api", "voters").GetJsonAsync<List<Voter>>();
            return candidates;
        }


        public Task PostVoteAsync(Vote.Model.Vote vote)
        {
            return _baseApiHost.AppendPathSegments("api", "vote").PostJsonAsync(vote);
        }


        public Task PostVoterAsync(Voter voter)
        {
            return _baseApiHost.AppendPathSegments("api", "voter").PostJsonAsync(voter);
        }

        public Task PostCandidateAsync(Candidate candidate)
        {
            return _baseApiHost.AppendPathSegments("api", "candidate").PostJsonAsync(candidate);
        }
    }
}
