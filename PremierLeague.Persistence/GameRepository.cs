using PremierLeague.Core.Contracts;
using PremierLeague.Core.Entities;
using System;
using System.Collections.Generic;
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

    public Task AddRangeAsync(IEnumerable<Game> games) => throw new NotImplementedException();
  }
}