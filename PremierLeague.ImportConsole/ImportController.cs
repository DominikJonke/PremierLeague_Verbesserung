using PremierLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace PremierLeague.ImportConsole
{
  public static class ImportController
  {
    public async static Task<IEnumerable<Game>> ReadFromCsvAsync()
    {
      string[][] matrix = await MyFile.ReadStringMatrixFromCsvAsync("PremierLeague.csv", false);  // keine Titelzeile
                                                                                                  // Einlesen der Spiele und der Teams
                                                                                                  // Zuerst die Teams
            var teams = matrix
                    .Select(team => team[1])
                    .Union(matrix.Select(column => column[2]))
                    .Select(team => new Team
                    {
                        Name = team
                    })
                    .ToArray();

            var games = matrix
                .Select(game => new Game
                {
                    Round = Convert.ToInt32(game[0]),
                    HomeTeam = teams.Single(team => team.Name == game[1]),
                    GuestTeam = teams.Single(team => team.Name == game[2]),
                    HomeGoals = Convert.ToInt32(game[3]),
                    GuestGoals = Convert.ToInt32(game[4])
                }).ToArray();

            return games;
    }
  }
}
