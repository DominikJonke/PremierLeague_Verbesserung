using PremierLeague.Core.Entities;
using System;
using System.Collections.Generic;
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

      throw new NotImplementedException();
    }

  }
}
