using System.Collections.Generic;
using System.Threading.Tasks;
using PremierLeague.Core.DataTransferObjects;
using PremierLeague.Core.Entities;

namespace PremierLeague.Core.Contracts
{
    public interface IGameRepository
    {
        Task AddRangeAsync(IEnumerable<Game> games);
        Task<IEnumerable<TeamTableRowDto>> GetAllAsync();
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task AddAsync(Game games);
    }
}