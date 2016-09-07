﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nether.Leaderboard.Data;

namespace Nether.Leaderboard.Data.InMemory
{
    public class InMemoryLeaderboardStore : ILeaderboardStore
    {        
        private static Dictionary<string, List<int>> leaderboard = new Dictionary<string, List<int>>();

        public async Task<IEnumerable<GameScore>> GetScoresAsync()
        {
            var result = new List<GameScore>();
            foreach (var item in leaderboard)
            {
                result.Add(new GameScore(item.Key, item.Value.Max()));
            }

            return result;
        }

        public Task SaveScoreAsync(string gamertag, int score)
        {
            if (leaderboard.ContainsKey(gamertag))
            {
                leaderboard[gamertag].Add(score);
            }
            else
            {
                leaderboard.Add(gamertag, new List<int>() { score });
            }
            return Task.CompletedTask;
        }

        public Task SaveScoresAsync(string gamertag, int score)
        {
            throw new NotImplementedException();
        }
    }
}