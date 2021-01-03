using Microsoft.EntityFrameworkCore;
using PremierLeague.Core.Contracts;
using PremierLeague.Core.DataTransferObjects;
using PremierLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Persistence
{
  public class GameRepository : IGameRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public GameRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

        public async Task AddRangeAsync(IEnumerable<Game> games) => await _dbContext.AddRangeAsync(games);

        public async Task<IEnumerable<TeamTableRowDto>> GetAllAsync()
        {
            var teams = await _dbContext.Teams
                .Select(team => new TeamTableRowDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    Matches = team.AwayGames.Count + team.HomeGames.Count,
                    Won = team.AwayGames.Count(game => game.GuestGoals > game.HomeGoals) + team.HomeGames.Count(game => game.HomeGoals > game.GuestGoals),
                    Lost = team.AwayGames.Count(game => game.GuestGoals < game.HomeGoals) + team.HomeGames.Count(game => game.HomeGoals < game.GuestGoals),
                    Plus = team.AwayGames.Sum(game => game.GuestGoals) + team.HomeGames.Sum(game => game.HomeGoals),
                    Minus = team.AwayGames.Sum(game => game.HomeGoals) + team.HomeGames.Sum(game => game.GuestGoals)
                }).ToArrayAsync();

            var orderTeams = teams
                .OrderByDescending(team => team.Points)
                .ThenByDescending(team => team.GoalDifference)
                .Select((team, idx) =>
                {
                    team.Rank = idx + 1;
                    return team;
                }).ToArray();

            return orderTeams;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return _dbContext.Games.ToList();
        }

        public async Task AddAsync(Game games)
        {
            await _dbContext.Games.AddAsync(games);
        }
    }
}