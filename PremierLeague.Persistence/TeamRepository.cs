using PremierLeague.Core.Contracts;
using PremierLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremierLeague.Persistence
{
  public class TeamRepository : ITeamRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public TeamRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Task AddRangeAsync(IEnumerable<Team> teams) => throw new NotImplementedException();
  }
}