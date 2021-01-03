using PremierLeague.Core.DataTransferObjects;
using PremierLeague.Persistence;
using PremierLeague.Wpf.Common;
using PremierLeague.Wpf.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PremierLeague.Wpf.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    public MainViewModel(IWindowController windowController) : base(windowController)
    {
      LoadCommands();
    }

    /// <summary>
    /// Erstellt die notwendigen Commands.
    /// </summary>
    private void LoadCommands()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchrones Laden von Daten für das ViewModel.
    /// Wird in CreateAsync(..) aufgerufen.
    /// </summary>
    /// <returns></returns>
    private async Task LoadDataAsync()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      throw new NotImplementedException();
    }

    public static async Task<MainViewModel> CreateAsync(IWindowController windowController)
    {
      var viewModel = new MainViewModel(windowController);
      await viewModel.LoadDataAsync();
      return viewModel;
    }
  }
}
