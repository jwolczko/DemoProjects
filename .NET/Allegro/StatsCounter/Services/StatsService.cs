using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatsCounter.Models;

namespace StatsCounter.Services
{
    public interface IStatsService
    {
        Task<RepositoryStats> GetRepositoryStatsByOwnerAsync(string owner);
    }
    
    public class StatsService : IStatsService
    {
        private readonly IGitHubService _gitHubService;

        public StatsService(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<RepositoryStats> GetRepositoryStatsByOwnerAsync(string owner)
        {
            var repositories = await _gitHubService.GetRepositoryInfosByOwnerAsync(owner);

            // Process data to calculate statistics
            var letterCounts = CalculateLetterCounts(repositories);
            var avgStargazers = repositories.Average(repo => repo.StargazersCount);
            var avgWatchers = repositories.Average(repo => repo.WatchersCount);
            var avgForks = repositories.Average(repo => repo.ForksCount);
            var avgSize = repositories.Average(repo => repo.Size);

            return new RepositoryStats
            {
                Owner = owner,
                Letters = letterCounts,
                AvgStargazers = avgStargazers,
                AvgWatchers = avgWatchers,
                AvgForks = avgForks,
                AvgSize = avgSize
            };
        }

        private Dictionary<char, int> CalculateLetterCounts(IEnumerable<RepositoryInfo> repositories)
        {
            var letterCounts = new Dictionary<char, int>();

            foreach (var repository in repositories)
            {
                string repositoryName = repository.Name.ToLower();

                foreach (char letter in repositoryName)
                {
                    if (char.IsLetter(letter))
                    {
                        if (letterCounts.ContainsKey(letter))
                        {
                            letterCounts[letter]++;
                        }
                        else
                        {
                            letterCounts[letter] = 1;
                        }
                    }
                }
            }

            return letterCounts;
        }
    }
}